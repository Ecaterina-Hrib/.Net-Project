using Microsoft.EntityFrameworkCore;

namespace HousePricePrediction.API.Users.DB
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }  
    }
}
