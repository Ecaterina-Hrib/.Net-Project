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

        private readonly UserService _userService;

        public HousesController(HouseService service, UserService userService)
        {
            this._service = service;
            this._userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHouseAsync(string username, House _newHouse)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            if (user.IsSuccess)
                _newHouse._user = user.User;
            else
            {
                return BadRequest(user.ErrorMessage);

            }
            Console.WriteLine(_newHouse._user._username);
            Console.WriteLine(user.User._username);

            var house = await _service.CreateHouseAsync(_newHouse);
            if (house.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest(house.ErrorMessage);
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
