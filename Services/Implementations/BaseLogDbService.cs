using System.Collections.Generic;
using System.Linq;
using LoggingService.Models;
using ServiceCore.Models;

namespace LoggingService.Services
{
    public abstract class BaseLogDbService<TDbContext> : IDbService
    where TDbContext : BaseApplicationDbContext<TDbContext>
    {
        private readonly TDbContext _context;
        public BaseLogDbService(
            TDbContext context
        )
        {
            _context = context;
        }

        public IEnumerable<Log> Get()
        {
            return _context.Logs.Take(100);
        }
    }
}