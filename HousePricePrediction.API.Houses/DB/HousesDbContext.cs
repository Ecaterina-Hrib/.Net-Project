using Microsoft.EntityFrameworkCore;

namespace HousePricePrediction.API.Houses.DB
{
    public class HousesDbContext : DbContext
    {
        public HousesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }

    }
}
