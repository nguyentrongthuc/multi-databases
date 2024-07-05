using ServiceCore.Models;

namespace LoggingService.Services
{
    public class Log1DbService : BaseLogDbService<Log1ApplicationDbContext>, ILogService
    {
        public Log1DbService(Log1ApplicationDbContext context) : base(context)
        {
        }
    }
}