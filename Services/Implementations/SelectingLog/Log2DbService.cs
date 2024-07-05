using ServiceCore.Models;

namespace LoggingService.Services
{
    public class Log2DbService : BaseLogDbService<Log2ApplicationDbContext>, ILogService
    {
        public Log2DbService(Log2ApplicationDbContext context) : base(context)
        {
        }
    }
}