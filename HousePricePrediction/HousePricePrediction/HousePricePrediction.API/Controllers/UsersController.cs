using HousePricePrediction.API.Entities;
using Microsoft.AspNetCore.Mvc;
using HousePricePrediction.API.Interfaces;
using HousePricePrediction.API.Resources;

namespace HousePricePrediction.API.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
   public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UsersController(IRepository<User> repository)
        {
            _userRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _userRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            User user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound(Messages.UserNotFoundMessage(id));
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            await _userRepository.CreateAsync(user);
            return CreatedAtAction("GetUserById", new { id = user.Id }, user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            if (user == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            if (!await _userRepository.ExistsAsync(user.Id))
            {
                return NotFound(Messages.UserNotFoundMessage(user.Id));
            }

            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveUser(Guid id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound(Messages.UserNotFoundMessage(id));
            }

            await _userRepository.RemoveAsync(user);
            return NoContent();
        }
    }
}
