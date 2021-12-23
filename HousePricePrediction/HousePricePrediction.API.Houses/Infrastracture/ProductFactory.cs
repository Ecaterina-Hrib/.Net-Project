using FII.eCommerce.API.Products.DB;

namespace FII.eCommerce.API.Products.Infrastracture
{
    public static class ProductFactory
    {
        public static ProductsDbContext SeedProducts(this ProductsDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.Add(new Product
                {
                    Id = new Guid("3f283fa8-2a75-4352-a73a-6df53c863986"),
                    Name = "Keyboard",
                    Price = 20,
                    Invertory = 100
                });
                context.Products.Add(new Product
                {
                    Id = new Guid("b101c022-2a80-49fa-bd46-cbaa3b7a25b3"),
                    Name = "Mouse",
                    Price = 5,
                    Invertory = 200
                });
                context.Products.Add(new Product
                {
                    Id = new Guid("65732eb3-71f2-46e5-8b45-9330b4d56bab"),
                    Name = "Monitor",
                    Price = 150,
                    Invertory = 20
                });
                context.Products.Add(new Product
                {
                    Id = new Guid("3349ad78-426b-4c0e-9e8f-e447af3d1984"),
                    Name = "CPU",
                    Price = 200,
                    Invertory = 20
                });
                context.SaveChanges();
            }
            return context;
        }
    }
}
