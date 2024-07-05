using ServiceCore.Models;

namespace LoggingService.Services
{
    public class UpdatingLog2DbService : BaseUpdatingLogDbService<Log1ApplicationDbContext>, IUpdatingLogService
    {
        public UpdatingLog2DbService(Log1ApplicationDbContext context) : base(context)
        {
        }
    }
}