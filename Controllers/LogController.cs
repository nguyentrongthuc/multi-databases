using LoggingService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoggingService.Controllers
{
    [Route("api/logs")]
    [ApiController]
    [
        Authorize(Roles = "QUAN_TRI",
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)
    ]
    public class LogController : ControllerBase
    {
        private readonly System.Func<string, ILogService> _DbService;
        public LogController(
            System.Func<string, ILogService> service
        )
        {
            _DbService = service;
        }
        [HttpGet("{LogName}")]
        public IActionResult Get([FromRoute] string LogName)
        {
            var service = _DbService(LogName);
            if (service != null)
            {
                var result = service.Get();
                return Ok(result);
            }
            return BadRequest("Log name khong ton tai");
        }
    }
}