namespace FII.eCommerce.API.Products.DB
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Invertory { get; set; }
    }
}
