using Microsoft.EntityFrameworkCore;
using HousePricePrediction.API.Models;


namespace HousePricePrediction.API.DB
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<House> Houses { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
                modelBuilder.Entity<House>()
                .ToTable("houses");
                // .HasOne(h => h._user)
                // .WithMany( u => u._forSell)
                // .IsRequired()
                // .HasForeignKey(h => h._id)
                // .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<User>().ToTable("users");


                base.OnModelCreating(modelBuilder);
         }
    }
}
