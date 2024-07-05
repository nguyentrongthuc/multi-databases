using ServiceCore.Models;

namespace LoggingService.Services
{
    public class UpdatingLog1DbService : BaseUpdatingLogDbService<Log1ApplicationDbContext>, IUpdatingLogService
    {
        public UpdatingLog1DbService(Log1ApplicationDbContext context) : base(context)
        {
        }
    }
}