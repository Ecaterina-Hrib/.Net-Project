using Microsoft.EntityFrameworkCore;

namespace FII.eCommerce.API.Products.DB
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

    }
}
