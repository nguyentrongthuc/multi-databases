using Microsoft.EntityFrameworkCore;

namespace ServiceCore.Models
{
    public class Log2ApplicationDbContext : BaseApplicationDbContext<Log2ApplicationDbContext>
    {
        public Log2ApplicationDbContext(DbContextOptions<Log2ApplicationDbContext> options) : base(options)
        {

        }
    }
}