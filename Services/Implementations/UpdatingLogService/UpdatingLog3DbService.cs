using ServiceCore.Models;

namespace LoggingService.Services
{
    public class UpdatingLog3DbService : BaseUpdatingLogDbService<Log1ApplicationDbContext>, IUpdatingLogService
    {
        public UpdatingLog3DbService(Log1ApplicationDbContext context) : base(context)
        {
        }
    }
}