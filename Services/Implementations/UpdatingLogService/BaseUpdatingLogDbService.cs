using LoggingService.Models;
using ServiceCore.Models;

namespace LoggingService.Services
{
    public abstract class BaseUpdatingLogDbService<TDbContext> : IUpdatingLogService
    where TDbContext : BaseApplicationDbContext<TDbContext>
    {
        private readonly TDbContext _context;
        public BaseUpdatingLogDbService(
            TDbContext context
        )
        {
            _context = context;
        }

        public void Create(Log log)
        {
            _context.Add(log);
            _context.SaveChanges();
        }
    }
}