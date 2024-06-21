using LoggingService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoggingService.Controllers
{
    [Route("api/logs")]
    [ApiController]
    [AllowAnonymous]
    public class AttendanceController : ControllerBase
    {
        private readonly System.Func<string, IDbService> _DbService;
        public AttendanceController(
            System.Func<string, IDbService> service
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