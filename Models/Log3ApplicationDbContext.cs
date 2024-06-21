using Microsoft.EntityFrameworkCore;

namespace ServiceCore.Models
{
    public class Log3ApplicationDbContext : BaseApplicationDbContext<Log3ApplicationDbContext>
    {
        public Log3ApplicationDbContext(DbContextOptions<Log3ApplicationDbContext> options) : base(options)
        {

        }
    }
}