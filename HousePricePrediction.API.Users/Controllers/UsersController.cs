using HousePricePrediction.API.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousePricePrediction.API.Users.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersProvider provider;

        public UsersController(IUsersProvider provider)
        {
            this.provider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await provider.GetUsersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Users);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await provider.GetUserAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }

    }
}
