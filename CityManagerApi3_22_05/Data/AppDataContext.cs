using CityManagerApi3_22_05.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityManagerApi3_22_05.Data
{
    public class AppDataContext:DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            :base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CityImage> CityImages { get; set; }
    }
}
