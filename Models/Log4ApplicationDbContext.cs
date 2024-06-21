using Microsoft.EntityFrameworkCore;

namespace ServiceCore.Models
{
    public class Log4ApplicationDbContext : BaseApplicationDbContext<Log4ApplicationDbContext>
    {
        public Log4ApplicationDbContext(DbContextOptions<Log4ApplicationDbContext> options) : base(options)
        {

        }
    }
}