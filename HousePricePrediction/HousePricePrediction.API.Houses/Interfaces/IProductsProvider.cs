namespace FII.eCommerce.API.Products.Interfaces
{
    public interface IProductsProvider
    {
        Task<(bool IsSuccess, IEnumerable<Model.ProductModel> Products, string ErrorMessage)> GetProductsAsync();
        Task<(bool IsSuccess,Model.ProductModel Product, string ErrorMessage)> GetProductAsync(Guid id);
    }
}
