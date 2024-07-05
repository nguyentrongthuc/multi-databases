using LoggingService.Models;
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
    public class UpdatingLogController : ControllerBase
    {
        private readonly System.Func<string, IUpdatingLogService> _DbService;
        public UpdatingLogController(
            System.Func<string, IUpdatingLogService> service
        )
        {
            _DbService = service;
        }
        [HttpPost("{LogName}")]
        public IActionResult Create([FromRoute] string LogName, [FromBody] Log log)
        {
            var service = _DbService(LogName);
            if (service != null)
            {
                service.Create(log);
                return Ok();
            }
            return BadRequest("Log name khong ton tai");
        }
    }
}