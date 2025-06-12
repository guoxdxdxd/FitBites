using Microsoft.AspNetCore.Mvc;

namespace FitBites.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("API正常运行中");
            return Ok(new { message = "欢迎使用FitBites健康菜谱管理系统API", version = "1.0.0", status = "运行正常" });
        }
    }
} 