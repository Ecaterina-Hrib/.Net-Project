using AutoMapper;
using FII.eCommerce.API.Products.DB;
using FII.eCommerce.API.Products.Infrastracture;
using FII.eCommerce.API.Products.Interfaces;
using FII.eCommerce.API.Products.Model;
using Microsoft.EntityFrameworkCore;

namespace FII.eCommerce.API.Products.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductsDbContext context;
        private readonly ILogger<ProductsProvider> logger;
        private readonly IMapper mapper;

        public ProductsProvider(ProductsDbContext context, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            context.SeedProducts();
        }

        public async Task<(bool IsSuccess, ProductModel Product, string ErrorMessage)> GetProductAsync(Guid id)
        {
            try
            {
                logger?.LogInformation("Quering products");
                var product = await context.Products.FirstOrDefaultAsync(p=>p.Id == id);
                if (product != null)
                {
                    var result = mapper.Map<ProductModel>(product);
                    return (true, result, null);
                }

                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ProductModel> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                logger?.LogInformation("Quering products");
                var products = await context.Products.ToListAsync();
                if (products != null && products.Any())
                {
                    logger?.LogInformation($"{products.Count} product(s) found");

                    var result = mapper.Map<IEnumerable<ProductModel>>(products);
                    return (true, result, null);
                }

                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
