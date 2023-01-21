using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }

        public DbSet<GeneralCost> GeneralCost
        {
            get;
            set;
        }
    }
}
