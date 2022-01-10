using HousePricePrediction.API.Services;
using HousePricePrediction.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HousePricePrediction.API.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(UserService _service)
        {
            this._service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(User _newUser)
        {
            var user = await _service.CreateUserAsync(_newUser);
            if (user.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest(user.ErrorMessage);
        }
                [HttpPost]
        public async Task<IActionResult> LoginUserAsync(UserCredentials user)
        {
            var login = await _service.Login(user._email, user._password);
            if (login.IsSuccess)
            {
                return Ok(login.Id);
            }

            return BadRequest(login.ErrorMessage);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetUsersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Users);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.GetUserAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }

    }
}
