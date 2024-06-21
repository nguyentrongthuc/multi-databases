using System.Collections.Generic;
using LoggingService.Models;

namespace LoggingService.Services
{
    public interface IDbService
    {
        IEnumerable<Log> Get();
    }
}