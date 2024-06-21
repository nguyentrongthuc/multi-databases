using ServiceCore.Models;

namespace LoggingService.Services
{
    public class Log3DbService : BaseLogDbService<Log3ApplicationDbContext>, IDbService
    {
        public Log3DbService(Log3ApplicationDbContext context) : base(context)
        {
        }
    }
}