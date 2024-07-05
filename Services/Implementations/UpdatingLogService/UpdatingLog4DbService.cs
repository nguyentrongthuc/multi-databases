using ServiceCore.Models;

namespace LoggingService.Services
{
    public class UpdatingLog4DbService : BaseUpdatingLogDbService<Log1ApplicationDbContext>, IUpdatingLogService
    {
        public UpdatingLog4DbService(Log1ApplicationDbContext context) : base(context)
        {
        }
    }
}