using HousePricePrediction.API.Services;
using HousePricePrediction.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HousePricePrediction.API.Controllers
{
    [Route("api/v1/houses")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly HouseService _service;

        public HousesController(HouseService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHouseAsync(House _newHouse)
        {
            var house = await _service.CreateHouseAsync(_newHouse);
            if (house.IsSuccess)
            {
                return NoContent();
            }

            return NotFound(house.ErrorMessage);
        }
        [HttpGet]
        public async Task<IActionResult> GetHousesAsync()
        {
            var houses = await _service.GetHousesAsync();
            if (houses.IsSuccess)
            {
                return Ok(houses.Houses);
            }

            return NotFound(houses.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHouseAsync(Guid id)
        {
            var house = await _service.GetHouseAsync(id);
            if (house.IsSuccess)
            {
                return Ok(house.House);
            }

            return NotFound(house.ErrorMessage);
        }

    }
}
