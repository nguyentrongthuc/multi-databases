using System.Collections.Generic;
using LoggingService.Models;

namespace LoggingService.Services
{
    public interface ILogService
    {
        IEnumerable<Log> Get();
    }
}