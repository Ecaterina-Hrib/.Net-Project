using HousePricePrediction.API.Entities;
using Microsoft.AspNetCore.Mvc;
using HousePricePrediction.API.Interfaces;
using HousePricePrediction.API.Resources;

namespace HousePricePrediction.API.Controllers
{
    [Route("api/v1/houses")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IRepository<House> _houseRepository;

        public HousesController(IRepository<House> repository)
        {
            _houseRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            return Ok(await _houseRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouseById(Guid id)
        {
            House house = await _houseRepository.GetByIdAsync(id);

            if (house == null)
            {
                return NotFound(Messages.HouseNotFoundMessage(id));
            }

            return Ok(house);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHouse(House house)
        {
            if (house == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            await _houseRepository.CreateAsync(house);
            return CreatedAtAction("GetHouseById", new { id = house.Id }, house);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHouse(House house)
        {
            if (house == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            if (!await _houseRepository.ExistsAsync(house.Id))
            {
                return NotFound(Messages.HouseNotFoundMessage(house.Id));
            }

            await _houseRepository.UpdateAsync(house);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveHouse(Guid id)
        {
            House house = await _houseRepository.GetByIdAsync(id);
            if (house == null)
            {
                return NotFound(Messages.HouseNotFoundMessage(id));
            }

            await _houseRepository.RemoveAsync(house);
            return NoContent();
        }
    }
}
