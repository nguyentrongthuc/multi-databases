using LoggingService.Models;

namespace LoggingService.Services
{
    public interface IUpdatingLogService
    {
        void Create(Log log);
    }
}