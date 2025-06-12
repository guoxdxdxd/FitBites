using System.IdentityModel.Tokens.Jwt;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FitBites.Core.Constants;
using FitBites.Core.Interfaces;
using FitBites.Infrastructure.Data;
using FitBites.Infrastructure.DependencyInjection;
using FitBites.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 使用Autofac作为服务提供者
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // 注册AutofacModule
    containerBuilder.RegisterModule(new AutofacModule(builder.Configuration));
});

// 配置数据库
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection") ?? DbConstants.DefaultMySqlConnection,
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection") ?? DbConstants.DefaultMySqlConnection),
        mySqlOptions =>
        {
            // 配置默认使用AsSplitQuery，提高关联查询性能
            mySqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        }
    );
});

// 配置Redis
// 从配置文件中读取Redis相关设置
var redisConfig = builder.Configuration.GetSection("Redis");
var redisConnectionString = redisConfig["ConnectionString"];
var redisInstanceName = redisConfig["InstanceName"] ?? "FitBites:";

// 只有在提供了Redis连接字符串时才注册Redis服务
// 这样可以根据不同环境灵活配置是否启用Redis
if (!string.IsNullOrEmpty(redisConnectionString))
{
    // 注册Redis连接多路复用器为单例
    // ConnectionMultiplexer是线程安全的，应当在应用程序生命周期内共享
    // 内部实现了连接池管理和自动重连机制
    builder.Services.AddSingleton<IConnectionMultiplexer>(sp => 
    {
        // 配置Redis连接选项
        var configOptions = ConfigurationOptions.Parse(redisConnectionString);
        configOptions.AbortOnConnectFail = false; // 连接失败时不终止应用
        configOptions.ConnectRetry = 3; // 连接重试次数
        configOptions.ConnectTimeout = 5000; // 连接超时时间(毫秒)
        
        // 创建日志记录器
        var logger = sp.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("正在连接Redis服务器: {ConnectionString}", redisConnectionString);
        
        // 创建Redis连接
        var redis = ConnectionMultiplexer.Connect(configOptions);
        
        // 订阅连接事件
        redis.ConnectionFailed += (sender, args) => {
            logger.LogError("Redis连接失败: {EndPoint}, {FailureType}", args.EndPoint, args.FailureType);
        };
        redis.ConnectionRestored += (sender, args) => {
            logger.LogInformation("Redis连接已恢复: {EndPoint}", args.EndPoint);
        };
        
        return redis;
    });
        
    // 注册Redis缓存服务为单例
    // 基于IConnectionMultiplexer封装了更友好的缓存操作API
    // 提供序列化/反序列化、异常处理等功能
    builder.Services.AddSingleton<ICacheService>(sp => 
        new RedisCacheService(
            sp.GetRequiredService<IConnectionMultiplexer>(),
            sp.GetRequiredService<ILogger<RedisCacheService>>(),
            redisInstanceName
        ));
    
    // 注册偏好缓存初始化后台服务
    // 在应用启动时自动将偏好数据加载到Redis缓存中
    builder.Services.AddHostedService<FitBites.API.Services.PreferenceCacheInitializer>();
    
    // 记录Redis服务注册成功
    builder.Services.BuildServiceProvider()
        .GetRequiredService<ILogger<Program>>()
        .LogInformation("Redis缓存服务已注册，实例前缀: {InstanceName}", redisInstanceName);
}
else
{
    // 记录Redis服务未配置的警告
    builder.Services.BuildServiceProvider()
        .GetRequiredService<ILogger<Program>>()
        .LogWarning("未配置Redis连接字符串，Redis缓存服务将不可用");
}

// 配置身份验证
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // 创建JwtService来获取统一的TokenValidationParameters
        var jwtService = new FitBites.Infrastructure.Services.JwtService(builder.Configuration);
        options.TokenValidationParameters = jwtService.GetTokenValidationParameters();
    });

// 配置CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular默认端口
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// 添加控制器和API探索
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FitBites API", Version = "v1", Description = "FitBites健康菜谱管理系统API" });
    
    // 添加XML注释文档
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    
    // 添加领域层XML注释
    var domainXmlFile = "FitBites.Domain.xml";
    var domainXmlPath = Path.Combine(AppContext.BaseDirectory, domainXmlFile);
    if (File.Exists(domainXmlPath))
    {
        c.IncludeXmlComments(domainXmlPath);
    }
    
    // 添加应用层XML注释
    var applicationXmlFile = "FitBites.Application.xml";
    var applicationXmlPath = Path.Combine(AppContext.BaseDirectory, applicationXmlFile);
    if (File.Exists(applicationXmlPath))
    {
        c.IncludeXmlComments(applicationXmlPath);
    }
    
    // 添加基础设施层XML注释
    var infrastructureXmlFile = "FitBites.Infrastructure.xml";
    var infrastructureXmlPath = Path.Combine(AppContext.BaseDirectory, infrastructureXmlFile);
    if (File.Exists(infrastructureXmlPath))
    {
        c.IncludeXmlComments(infrastructureXmlPath);
    }
    
    // 添加JWT认证支持
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// 配置HTTP请求管道
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FitBites API V1");
        c.RoutePrefix = string.Empty; // 设置Swagger UI的根路径
    });
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
