using Microsoft.EntityFrameworkCore;


namespace HousePricePrediction.API.Houses.DB
{
    public class HouseDbContext : DbContext
    {
        public HouseDbContext (DbContextOptions<HouseDbContext> options) : base(options)
        {

        }

        //  protected override void OnModelCreating(ModelBuilder modelBuilder)
        //  {
        //     modelBuilder.Entity<House>()
        //  }

        public DbSet<House>? Houses { get; set; }
        // public DbSet<User>? Users { get; set; }
    }
}
