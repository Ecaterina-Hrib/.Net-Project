using Microsoft.EntityFrameworkCore;

namespace HousePricePrediction.API.Users.DB
{
    public class UsersDbContext : DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EFCore-SchoolDB;Trusted_Connection=True");
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<User>()
                .HasOne<User>(u => u.User)
                .WithMany(h => h.House)
                .HasForeignKey(u => u.id)
                .OnDelete(DeleteBehavior.Cascade);
         }

        public DbSet<House>? Houses { get; set; }
        public DbSet<User>? Users { get; set; } 
    }
}
