namespace FII.eCommerce.API.Products.Model
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Inventory { get; set; }
    }
}
