using Microsoft.EntityFrameworkCore;
using LoggingService.Models;

namespace ServiceCore.Models
{
    public abstract class BaseApplicationDbContext<TContext> : DbContext
    where TContext : DbContext
    {
        public BaseApplicationDbContext(DbContextOptions<TContext> options) : base(options)
        {

        }
        public DbSet<Log> Logs { get; set; }
    }
}