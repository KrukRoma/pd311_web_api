using Microsoft.EntityFrameworkCore;
using pd311_web_api.DAL.Entities;

namespace pd311_web_api.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options){ }

        public DbSet<Car> Cars { get; set; }
    }
}
