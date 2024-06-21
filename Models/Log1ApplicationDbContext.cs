using Microsoft.EntityFrameworkCore;

namespace ServiceCore.Models
{
    public class Log1ApplicationDbContext : BaseApplicationDbContext<Log1ApplicationDbContext>
    {
        public Log1ApplicationDbContext(DbContextOptions<Log1ApplicationDbContext> options) : base(options)
        {

        }
    }
}