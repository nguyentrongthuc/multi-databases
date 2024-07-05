using ServiceCore.Models;

namespace LoggingService.Services
{
    public class Log3DbService : BaseLogDbService<Log3ApplicationDbContext>, ILogService
    {
        public Log3DbService(Log3ApplicationDbContext context) : base(context)
        {
        }
    }
}