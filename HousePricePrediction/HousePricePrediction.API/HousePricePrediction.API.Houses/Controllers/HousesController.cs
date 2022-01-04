using HousePricePrediction.API.Houses.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FHousePricePrediction.API.Houses.Controllers
{
    [Route("api/v1/houses")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IHousesProvider provider;

        public HousesController(IHousesProvider provider)
        {
            this.provider = provider;
        }
        [HttpGet]
        public async Task<IActionResult> GetHousesAsync()
        {
            var houses = await provider.GetHousesAsync();
            if (houses.IsSuccess)
            {
                return Ok(houses.Houses);
            }

            return NotFound(houses.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHouseAsync(Guid id)
        {
            var house = await provider.GetHouseAsync(id);
            if (house.IsSuccess)
            {
                return Ok(house.House);
            }

            return NotFound(house.ErrorMessage);
        }

    }
}
