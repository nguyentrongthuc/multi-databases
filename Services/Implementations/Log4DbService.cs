using ServiceCore.Models;

namespace LoggingService.Services
{
    public class Log4DbService : BaseLogDbService<Log4ApplicationDbContext>, IDbService
    {
        public Log4DbService(Log4ApplicationDbContext context) : base(context)
        {
        }
    }
}