namespace HousePricePrediction.API.Houses.DB;
using Microsoft.EntityFrameworkCore;

namespace HousePricePrediction.API.Houses.DB
{
    public class HouseDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DafaultConnection"));
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<House>()
                .HasOne<User>(u => u.Users)
                .WithMany(h => h.Houses)
                .HasForeignKey(u => u.id)
                .OnDelete(DeleteBehavior.Cascade);
         }

        public DbSet<House>? Houses { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
