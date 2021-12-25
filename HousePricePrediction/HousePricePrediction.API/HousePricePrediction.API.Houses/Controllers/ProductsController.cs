using FII.eCommerce.API.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FII.eCommerce.API.Products.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider provider;

        public ProductsController(IProductsProvider provider)
        {
            this.provider = provider;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await provider.GetProductsAsync();
            if (products.IsSuccess)
            {
                return Ok(products.Products);
            }

            return NotFound(products.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(Guid id)
        {
            var product = await provider.GetProductAsync(id);
            if (product.IsSuccess)
            {
                return Ok(product.Product);
            }

            return NotFound(product.ErrorMessage);
        }

    }
}
