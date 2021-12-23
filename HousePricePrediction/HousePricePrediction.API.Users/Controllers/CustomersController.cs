using FII.eCommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FII.eCommerce.Api.Customers.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider provider;

        public CustomersController(ICustomersProvider provider)
        {
            this.provider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await provider.GetCustomersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await provider.GetCustomerAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Customer);
            }
            return NotFound();
        }

    }
}
