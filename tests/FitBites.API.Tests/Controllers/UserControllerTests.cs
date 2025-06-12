using System;
using System.Threading.Tasks;
using FitBites.API.Controllers;
using FitBites.Application.DTOs;
using FitBites.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using FluentAssertions;

namespace FitBites.API.Tests.Controllers
{
    /// <summary>
    /// UserController控制器的单元测试
    /// </summary>
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<ILogger<UserController>> _mockLogger;
        private readonly UserController _controller;

        /// <summary>
        /// 构造函数
        /// 初始化所有测试用例共用的模拟对象和控制器实例
        /// </summary>
        public UserControllerTests()
        {
            // 创建模拟对象
            _mockUserService = new Mock<IUserService>();
            _mockLogger = new Mock<ILogger<UserController>>();

            // 创建控制器实例，注入模拟的依赖
            _controller = new UserController(_mockUserService.Object, _mockLogger.Object);
        }

        #region Login方法测试

        /// <summary>
        /// 测试用例：使用有效凭据登录时应返回成功结果
        /// 验证点：
        /// 1. 应返回200 OK状态码
        /// 2. 返回的数据应包含正确的用户信息和令牌
        /// 3. 返回的消息应为"登录成功"
        /// </summary>
        [Fact]
        public async Task Login_WithValidCredentials_ShouldReturnOkResult()
        {
            // Arrange - 准备测试数据和环境
            var userLoginDto = new UserLoginDto
            {
                Account = "testuser",
                Password = "password123"
            };

            var userId = Guid.NewGuid();
            var userDto = new UserDto
            {
                Id = userId,
                UserCode = "U202406110001",
                Username = "testuser",
                Phone = "13800138000",
                Nickname = "快乐的厨师10",
                Avatar = string.Empty,
                CreatedAt = DateTime.Now
            };

            var loginResponseDto = new UserLoginResponseDto
            {
                User = userDto,
                AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
                TokenType = "Bearer",
                ExpiresIn = 60
            };

            // 配置模拟行为：登录方法返回登录响应DTO
            _mockUserService.Setup(service => service.LoginAsync(It.IsAny<UserLoginDto>()))
                .ReturnsAsync(loginResponseDto);

            // Act - 执行被测试的方法
            var result = await _controller.Login(userLoginDto);

            // Assert - 验证结果
            // 验证返回类型为OkObjectResult（200 OK）
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            
            // 验证返回的状态码为200
            okResult.StatusCode.Should().Be(200);
            
            // 验证返回的数据类型为ApiResult<UserLoginResponseDto>
            var apiResult = okResult.Value.Should().BeOfType<ApiResult<UserLoginResponseDto>>().Subject;
            
            // 验证ApiResult的Code为0（表示成功）
            apiResult.Code.Should().Be(0, "成功的API结果Code应为0");
            
            // 验证ApiResult的Message为"登录成功"
            apiResult.Message.Should().Be("登录成功", "成功登录应返回'登录成功'消息");
            
            // 验证返回的Data不为null且包含正确的用户信息和令牌
            apiResult.Data.Should().NotBeNull("返回的登录数据不应为null");
            apiResult.Data.User.Should().NotBeNull("返回的用户信息不应为null");
            apiResult.Data.User.Id.Should().Be(userId, "返回的用户ID应与服务返回的一致");
            apiResult.Data.AccessToken.Should().NotBeNullOrEmpty("返回的访问令牌不应为空");
            
            // 验证UserService的LoginAsync方法被调用
            _mockUserService.Verify(service => service.LoginAsync(It.IsAny<UserLoginDto>()), Times.Once, "应调用UserService的LoginAsync方法");
        }

        /// <summary>
        /// 测试用例：当ModelState无效时登录应返回BadRequest
        /// 验证点：
        /// 1. 应返回400 BadRequest状态码
        /// 2. 返回的消息应包含错误信息
        /// </summary>
        [Fact]
        public async Task Login_WithInvalidModelState_ShouldReturnBadRequest()
        {
            // Arrange - 准备测试数据和环境
            var userLoginDto = new UserLoginDto
            {
                // 故意不设置必填字段，使ModelState无效
            };

            // 添加ModelState错误
            _controller.ModelState.AddModelError("Account", "用户名/手机号不能为空");

            // Act - 执行被测试的方法
            var result = await _controller.Login(userLoginDto);

            // Assert - 验证结果
            // 验证返回类型为BadRequestObjectResult（400 BadRequest）
            var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
            
            // 验证返回的状态码为400
            badRequestResult.StatusCode.Should().Be(400);
            
            // 验证返回的数据类型为ApiResult<string>
            var apiResult = badRequestResult.Value.Should().BeOfType<ApiResult<string>>().Subject;
            
            // 验证ApiResult的Code不为0（表示失败）
            apiResult.Code.Should().NotBe(0, "失败的API结果Code不应为0");
            
            // 验证ApiResult的Message包含错误信息
            apiResult.Message.Should().Be("请求参数错误", "参数错误应返回对应的错误消息");
            
            // 验证UserService的LoginAsync方法未被调用
            _mockUserService.Verify(service => service.LoginAsync(It.IsAny<UserLoginDto>()), Times.Never, "不应调用UserService的LoginAsync方法");
        }

        /// <summary>
        /// 测试用例：当用户名或密码错误时登录应返回BadRequest
        /// 验证点：
        /// 1. 应返回400 BadRequest状态码
        /// 2. 返回的消息应包含"用户名/手机号或密码错误"
        /// </summary>
        [Fact]
        public async Task Login_WithInvalidCredentials_ShouldReturnBadRequest()
        {
            // Arrange - 准备测试数据和环境
            var userLoginDto = new UserLoginDto
            {
                Account = "testuser",
                Password = "wrongpassword"
            };

            // 配置模拟行为：登录方法抛出ApplicationException异常
            _mockUserService.Setup(service => service.LoginAsync(It.IsAny<UserLoginDto>()))
                .ThrowsAsync(new ApplicationException("用户名/手机号或密码错误"));

            // Act - 执行被测试的方法
            var result = await _controller.Login(userLoginDto);

            // Assert - 验证结果
            // 验证返回类型为BadRequestObjectResult（400 BadRequest）
            var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
            
            // 验证返回的状态码为400
            badRequestResult.StatusCode.Should().Be(400);
            
            // 验证返回的数据类型为ApiResult<string>
            var apiResult = badRequestResult.Value.Should().BeOfType<ApiResult<string>>().Subject;
            
            // 验证ApiResult的Code不为0（表示失败）
            apiResult.Code.Should().NotBe(0, "失败的API结果Code不应为0");
            
            // 验证ApiResult的Message包含错误信息
            apiResult.Message.Should().Be("用户名/手机号或密码错误", "登录失败应返回对应的错误消息");
            
            // 验证UserService的LoginAsync方法被调用
            _mockUserService.Verify(service => service.LoginAsync(It.IsAny<UserLoginDto>()), Times.Once, "应调用UserService的LoginAsync方法");
        }

        /// <summary>
        /// 测试用例：当发生未处理的异常时登录应返回500内部服务器错误
        /// 验证点：
        /// 1. 应返回500 InternalServerError状态码
        /// 2. 返回的消息应为通用错误消息
        /// </summary>
        [Fact]
        public async Task Login_WithUnhandledException_ShouldReturnInternalServerError()
        {
            // Arrange - 准备测试数据和环境
            var userLoginDto = new UserLoginDto
            {
                Account = "testuser",
                Password = "password123"
            };

            // 配置模拟行为：登录方法抛出一个未处理的异常
            _mockUserService.Setup(service => service.LoginAsync(It.IsAny<UserLoginDto>()))
                .ThrowsAsync(new Exception("数据库连接失败"));

            // Act - 执行被测试的方法
            var result = await _controller.Login(userLoginDto);

            // Assert - 验证结果
            // 验证返回类型为ObjectResult
            var objectResult = result.Should().BeOfType<ObjectResult>().Subject;
            
            // 验证返回的状态码为500
            objectResult.StatusCode.Should().Be(500);
            
            // 验证返回的数据类型为ApiResult<string>
            var apiResult = objectResult.Value.Should().BeOfType<ApiResult<string>>().Subject;
            
            // 验证ApiResult的Code不为0（表示失败）
            apiResult.Code.Should().NotBe(0, "失败的API结果Code不应为0");
            
            // 验证ApiResult的Message为通用错误消息
            apiResult.Message.Should().Be("服务器内部错误，请稍后再试", "内部服务器错误应返回通用错误消息");
            
            // 验证UserService的LoginAsync方法被调用
            _mockUserService.Verify(service => service.LoginAsync(It.IsAny<UserLoginDto>()), Times.Once, "应调用UserService的LoginAsync方法");
            
            // 验证Logger记录了错误
            _mockLogger.Verify(
                logger => logger.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once,
                "应该记录错误日志");
        }

        #endregion

        #region Register方法测试

        /// <summary>
        /// 测试用例：使用有效数据注册用户时应返回成功结果
        /// 验证点：
        /// 1. 应返回200 OK状态码
        /// 2. 返回的数据应包含正确的用户信息
        /// 3. 返回的消息应为"注册成功"
        /// </summary>
        [Fact]
        public async Task Register_WithValidData_ShouldReturnOkResult()
        {
            // Arrange - 准备测试数据和环境
            var userRegisterDto = new UserRegisterDto
            {
                Username = "testuser",
                Password = "password123",
                Phone = "13800138000"
            };

            var userDto = new UserDto
            {
                Id = Guid.NewGuid(),
                UserCode = "U202406110001",
                Username = "testuser",
                Phone = "13800138000",
                Nickname = "快乐的厨师10",
                Avatar = string.Empty,
                CreatedAt = DateTime.Now
            };

            // 配置模拟行为：注册方法返回用户DTO
            _mockUserService.Setup(service => service.RegisterAsync(It.IsAny<UserRegisterDto>()))
                .ReturnsAsync(userDto);

            // Act - 执行被测试的方法
            var result = await _controller.Register(userRegisterDto);

            // Assert - 验证结果
            // 验证返回类型为OkObjectResult（200 OK）
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            
            // 验证返回的状态码为200
            okResult.StatusCode.Should().Be(200);
            
            // 验证返回的数据类型为ApiResult<UserDto>
            var apiResult = okResult.Value.Should().BeOfType<ApiResult<UserDto>>().Subject;
            
            // 验证ApiResult的Code为0（表示成功）
            apiResult.Code.Should().Be(0, "成功的API结果Code应为0");
            
            // 验证ApiResult的Message为"注册成功"
            apiResult.Message.Should().Be("注册成功", "成功注册应返回'注册成功'消息");
            
            // 验证返回的Data不为null且包含正确的用户信息
            apiResult.Data.Should().NotBeNull("返回的用户数据不应为null");
            apiResult.Data.Username.Should().Be(userRegisterDto.Username, "返回的用户名应与注册时提供的一致");
            apiResult.Data.Phone.Should().Be(userRegisterDto.Phone, "返回的手机号应与注册时提供的一致");
            
            // 验证UserService的RegisterAsync方法被调用
            _mockUserService.Verify(service => service.RegisterAsync(It.IsAny<UserRegisterDto>()), Times.Once, "应调用UserService的RegisterAsync方法");
        }

        /// <summary>
        /// 测试用例：当ModelState无效时注册应返回BadRequest
        /// 验证点：
        /// 1. 应返回400 BadRequest状态码
        /// 2. 返回的消息应包含错误信息
        /// </summary>
        [Fact]
        public async Task Register_WithInvalidModelState_ShouldReturnBadRequest()
        {
            // Arrange - 准备测试数据和环境
            var userRegisterDto = new UserRegisterDto
            {
                // 故意不设置必填字段，使ModelState无效
            };

            // 添加ModelState错误
            _controller.ModelState.AddModelError("Username", "用户名不能为空");

            // Act - 执行被测试的方法
            var result = await _controller.Register(userRegisterDto);

            // Assert - 验证结果
            // 验证返回类型为BadRequestObjectResult（400 BadRequest）
            var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
            
            // 验证返回的状态码为400
            badRequestResult.StatusCode.Should().Be(400);
            
            // 验证返回的数据类型为ApiResult<string>
            var apiResult = badRequestResult.Value.Should().BeOfType<ApiResult<string>>().Subject;
            
            // 验证ApiResult的Code不为0（表示失败）
            apiResult.Code.Should().NotBe(0, "失败的API结果Code不应为0");
            
            // 验证ApiResult的Message包含错误信息
            apiResult.Message.Should().Be("请求参数错误", "参数错误应返回对应的错误消息");
            
            // 验证UserService的RegisterAsync方法未被调用
            _mockUserService.Verify(service => service.RegisterAsync(It.IsAny<UserRegisterDto>()), Times.Never, "不应调用UserService的RegisterAsync方法");
        }

        /// <summary>
        /// 测试用例：当用户名已存在时注册应返回BadRequest
        /// 验证点：
        /// 1. 应返回400 BadRequest状态码
        /// 2. 返回的消息应包含"用户名已存在"
        /// </summary>
        [Fact]
        public async Task Register_WithExistingUsername_ShouldReturnBadRequest()
        {
            // Arrange - 准备测试数据和环境
            var userRegisterDto = new UserRegisterDto
            {
                Username = "existinguser",
                Password = "password123",
                Phone = "13800138000"
            };

            // 配置模拟行为：注册方法抛出ApplicationException异常
            _mockUserService.Setup(service => service.RegisterAsync(It.IsAny<UserRegisterDto>()))
                .ThrowsAsync(new ApplicationException("用户名已存在"));

            // Act - 执行被测试的方法
            var result = await _controller.Register(userRegisterDto);

            // Assert - 验证结果
            // 验证返回类型为BadRequestObjectResult（400 BadRequest）
            var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
            
            // 验证返回的状态码为400
            badRequestResult.StatusCode.Should().Be(400);
            
            // 验证返回的数据类型为ApiResult<string>
            var apiResult = badRequestResult.Value.Should().BeOfType<ApiResult<string>>().Subject;
            
            // 验证ApiResult的Code不为0（表示失败）
            apiResult.Code.Should().NotBe(0, "失败的API结果Code不应为0");
            
            // 验证ApiResult的Message包含错误信息
            apiResult.Message.Should().Be("用户名已存在", "用户名已存在错误应返回对应的错误消息");
            
            // 验证UserService的RegisterAsync方法被调用
            _mockUserService.Verify(service => service.RegisterAsync(It.IsAny<UserRegisterDto>()), Times.Once, "应调用UserService的RegisterAsync方法");
        }

        /// <summary>
        /// 测试用例：当发生未处理的异常时注册应返回500内部服务器错误
        /// 验证点：
        /// 1. 应返回500 InternalServerError状态码
        /// 2. 返回的消息应为通用错误消息
        /// </summary>
        [Fact]
        public async Task Register_WithUnhandledException_ShouldReturnInternalServerError()
        {
            // Arrange - 准备测试数据和环境
            var userRegisterDto = new UserRegisterDto
            {
                Username = "testuser",
                Password = "password123",
                Phone = "13800138000"
            };

            // 配置模拟行为：注册方法抛出一个未处理的异常
            _mockUserService.Setup(service => service.RegisterAsync(It.IsAny<UserRegisterDto>()))
                .ThrowsAsync(new Exception("数据库连接失败"));

            // Act - 执行被测试的方法
            var result = await _controller.Register(userRegisterDto);

            // Assert - 验证结果
            // 验证返回类型为ObjectResult
            var objectResult = result.Should().BeOfType<ObjectResult>().Subject;
            
            // 验证返回的状态码为500
            objectResult.StatusCode.Should().Be(500);
            
            // 验证返回的数据类型为ApiResult<string>
            var apiResult = objectResult.Value.Should().BeOfType<ApiResult<string>>().Subject;
            
            // 验证ApiResult的Code不为0（表示失败）
            apiResult.Code.Should().NotBe(0, "失败的API结果Code不应为0");
            
            // 验证ApiResult的Message为通用错误消息
            apiResult.Message.Should().Be("服务器内部错误，请稍后再试", "内部服务器错误应返回通用错误消息");
            
            // 验证UserService的RegisterAsync方法被调用
            _mockUserService.Verify(service => service.RegisterAsync(It.IsAny<UserRegisterDto>()), Times.Once, "应调用UserService的RegisterAsync方法");
            
            // 验证Logger记录了错误
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once, 
                "应记录错误日志"
            );
        }

        #endregion

        #region CheckUsername方法测试

        /// <summary>
        /// 测试用例：检查不存在的用户名应返回用户名可用
        /// 验证点：
        /// 1. 应返回200 OK状态码
        /// 2. Data应为true（表示可用）
        /// 3. 消息应为"用户名可用"
        /// </summary>
        [Fact]
        public async Task CheckUsername_WithNonExistingUsername_ShouldReturnAvailable()
        {
            // Arrange - 准备测试数据和环境
            var username = "newuser";

            // 配置模拟行为：用户名不存在
            _mockUserService.Setup(service => service.IsUsernameExistsAsync(username))
                .ReturnsAsync(false);

            // Act - 执行被测试的方法
            var result = await _controller.CheckUsername(username);

            // Assert - 验证结果
            // 验证返回类型为OkObjectResult（200 OK）
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            
            // 验证返回的状态码为200
            okResult.StatusCode.Should().Be(200);
            
            // 验证返回的数据类型为ApiResult<bool>
            var apiResult = okResult.Value.Should().BeOfType<ApiResult<bool>>().Subject;
            
            // 验证ApiResult的Code为0（表示成功）
            apiResult.Code.Should().Be(0, "成功的API结果Code应为0");
            
            // 验证ApiResult的Data为true（表示用户名可用）
            apiResult.Data.Should().BeTrue("用户名不存在时应返回true表示可用");
            
            // 验证ApiResult的Message为"用户名可用"
            apiResult.Message.Should().Be("用户名可用", "用户名不存在应返回'用户名可用'消息");
            
            // 验证UserService的IsUsernameExistsAsync方法被调用
            _mockUserService.Verify(service => service.IsUsernameExistsAsync(username), Times.Once, "应调用UserService的IsUsernameExistsAsync方法");
        }

        /// <summary>
        /// 测试用例：检查已存在的用户名应返回用户名不可用
        /// 验证点：
        /// 1. 应返回200 OK状态码
        /// 2. Data应为false（表示不可用）
        /// 3. 消息应为"用户名已存在"
        /// </summary>
        [Fact]
        public async Task CheckUsername_WithExistingUsername_ShouldReturnNotAvailable()
        {
            // Arrange - 准备测试数据和环境
            var username = "existinguser";

            // 配置模拟行为：用户名已存在
            _mockUserService.Setup(service => service.IsUsernameExistsAsync(username))
                .ReturnsAsync(true);

            // Act - 执行被测试的方法
            var result = await _controller.CheckUsername(username);

            // Assert - 验证结果
            // 验证返回类型为OkObjectResult（200 OK）
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            
            // 验证返回的状态码为200
            okResult.StatusCode.Should().Be(200);
            
            // 验证返回的数据类型为ApiResult<bool>
            var apiResult = okResult.Value.Should().BeOfType<ApiResult<bool>>().Subject;
            
            // 验证ApiResult的Code为0（表示成功）
            apiResult.Code.Should().Be(0, "成功的API结果Code应为0");
            
            // 验证ApiResult的Data为false（表示用户名不可用）
            apiResult.Data.Should().BeFalse("用户名已存在时应返回false表示不可用");
            
            // 验证ApiResult的Message为"用户名已存在"
            apiResult.Message.Should().Be("用户名已存在", "用户名已存在应返回'用户名已存在'消息");
            
            // 验证UserService的IsUsernameExistsAsync方法被调用
            _mockUserService.Verify(service => service.IsUsernameExistsAsync(username), Times.Once, "应调用UserService的IsUsernameExistsAsync方法");
        }

        /// <summary>
        /// 测试用例：检查用户名时发生异常应返回500内部服务器错误
        /// 验证点：
        /// 1. 应返回500 InternalServerError状态码
        /// 2. 返回的消息应为通用错误消息
        /// </summary>
        [Fact]
        public async Task CheckUsername_WithException_ShouldReturnInternalServerError()
        {
            // Arrange - 准备测试数据和环境
            var username = "testuser";

            // 配置模拟行为：方法抛出异常
            _mockUserService.Setup(service => service.IsUsernameExistsAsync(username))
                .ThrowsAsync(new Exception("数据库连接失败"));

            // Act - 执行被测试的方法
            var result = await _controller.CheckUsername(username);

            // Assert - 验证结果
            // 验证返回类型为ObjectResult
            var objectResult = result.Should().BeOfType<ObjectResult>().Subject;
            
            // 验证返回的状态码为500
            objectResult.StatusCode.Should().Be(500);
            
            // 验证返回的数据类型为ApiResult<string>
            var apiResult = objectResult.Value.Should().BeOfType<ApiResult<string>>().Subject;
            
            // 验证ApiResult的Code不为0（表示失败）
            apiResult.Code.Should().NotBe(0, "失败的API结果Code不应为0");
            
            // 验证ApiResult的Message为通用错误消息
            apiResult.Message.Should().Be("服务器内部错误，请稍后再试", "内部服务器错误应返回通用错误消息");
            
            // 验证UserService的IsUsernameExistsAsync方法被调用
            _mockUserService.Verify(service => service.IsUsernameExistsAsync(username), Times.Once, "应调用UserService的IsUsernameExistsAsync方法");
            
            // 验证Logger记录了错误
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once, 
                "应记录错误日志"
            );
        }

        #endregion

        #region CheckPhone方法测试

        /// <summary>
        /// 测试用例：检查不存在的手机号应返回手机号可用
        /// 验证点：
        /// 1. 应返回200 OK状态码
        /// 2. Data应为true（表示可用）
        /// 3. 消息应为"手机号可用"
        /// </summary>
        [Fact]
        public async Task CheckPhone_WithNonExistingPhone_ShouldReturnAvailable()
        {
            // Arrange - 准备测试数据和环境
            var phone = "13800138001";

            // 配置模拟行为：手机号不存在
            _mockUserService.Setup(service => service.IsPhoneExistsAsync(phone))
                .ReturnsAsync(false);

            // Act - 执行被测试的方法
            var result = await _controller.CheckPhone(phone);

            // Assert - 验证结果
            // 验证返回类型为OkObjectResult（200 OK）
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            
            // 验证返回的状态码为200
            okResult.StatusCode.Should().Be(200);
            
            // 验证返回的数据类型为ApiResult<bool>
            var apiResult = okResult.Value.Should().BeOfType<ApiResult<bool>>().Subject;
            
            // 验证ApiResult的Code为0（表示成功）
            apiResult.Code.Should().Be(0, "成功的API结果Code应为0");
            
            // 验证ApiResult的Data为true（表示手机号可用）
            apiResult.Data.Should().BeTrue("手机号不存在时应返回true表示可用");
            
            // 验证ApiResult的Message为"手机号可用"
            apiResult.Message.Should().Be("手机号可用", "手机号不存在应返回'手机号可用'消息");
            
            // 验证UserService的IsPhoneExistsAsync方法被调用
            _mockUserService.Verify(service => service.IsPhoneExistsAsync(phone), Times.Once, "应调用UserService的IsPhoneExistsAsync方法");
        }

        /// <summary>
        /// 测试用例：检查已存在的手机号应返回手机号不可用
        /// 验证点：
        /// 1. 应返回200 OK状态码
        /// 2. Data应为false（表示不可用）
        /// 3. 消息应为"手机号已存在"
        /// </summary>
        [Fact]
        public async Task CheckPhone_WithExistingPhone_ShouldReturnNotAvailable()
        {
            // Arrange - 准备测试数据和环境
            var phone = "13800138000";

            // 配置模拟行为：手机号已存在
            _mockUserService.Setup(service => service.IsPhoneExistsAsync(phone))
                .ReturnsAsync(true);

            // Act - 执行被测试的方法
            var result = await _controller.CheckPhone(phone);

            // Assert - 验证结果
            // 验证返回类型为OkObjectResult（200 OK）
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            
            // 验证返回的状态码为200
            okResult.StatusCode.Should().Be(200);
            
            // 验证返回的数据类型为ApiResult<bool>
            var apiResult = okResult.Value.Should().BeOfType<ApiResult<bool>>().Subject;
            
            // 验证ApiResult的Code为0（表示成功）
            apiResult.Code.Should().Be(0, "成功的API结果Code应为0");
            
            // 验证ApiResult的Data为false（表示手机号不可用）
            apiResult.Data.Should().BeFalse("手机号已存在时应返回false表示不可用");
            
            // 验证ApiResult的Message为"手机号已存在"
            apiResult.Message.Should().Be("手机号已存在", "手机号已存在应返回'手机号已存在'消息");
            
            // 验证UserService的IsPhoneExistsAsync方法被调用
            _mockUserService.Verify(service => service.IsPhoneExistsAsync(phone), Times.Once, "应调用UserService的IsPhoneExistsAsync方法");
        }

        /// <summary>
        /// 测试用例：检查手机号时发生异常应返回500内部服务器错误
        /// 验证点：
        /// 1. 应返回500 InternalServerError状态码
        /// 2. 返回的消息应为通用错误消息
        /// </summary>
        [Fact]
        public async Task CheckPhone_WithException_ShouldReturnInternalServerError()
        {
            // Arrange - 准备测试数据和环境
            var phone = "13800138000";

            // 配置模拟行为：方法抛出异常
            _mockUserService.Setup(service => service.IsPhoneExistsAsync(phone))
                .ThrowsAsync(new Exception("数据库连接失败"));

            // Act - 执行被测试的方法
            var result = await _controller.CheckPhone(phone);

            // Assert - 验证结果
            // 验证返回类型为ObjectResult
            var objectResult = result.Should().BeOfType<ObjectResult>().Subject;
            
            // 验证返回的状态码为500
            objectResult.StatusCode.Should().Be(500);
            
            // 验证返回的数据类型为ApiResult<string>
            var apiResult = objectResult.Value.Should().BeOfType<ApiResult<string>>().Subject;
            
            // 验证ApiResult的Code不为0（表示失败）
            apiResult.Code.Should().NotBe(0, "失败的API结果Code不应为0");
            
            // 验证ApiResult的Message为通用错误消息
            apiResult.Message.Should().Be("服务器内部错误，请稍后再试", "内部服务器错误应返回通用错误消息");
            
            // 验证UserService的IsPhoneExistsAsync方法被调用
            _mockUserService.Verify(service => service.IsPhoneExistsAsync(phone), Times.Once, "应调用UserService的IsPhoneExistsAsync方法");
            
            // 验证Logger记录了错误
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once, 
                "应记录错误日志"
            );
        }

        #endregion
    }
} 