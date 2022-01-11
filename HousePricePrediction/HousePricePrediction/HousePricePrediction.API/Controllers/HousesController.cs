using HousePricePrediction.API.Services;
using HousePricePrediction.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HousePricePrediction.API.Controllers
{
    [Route("api/v1/houses")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private const string BASE_URL = "https://house-prediction-ml-module.herokuapp.com/Price";
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
                {
                    _newHouse._user = user.User;
                }
            else
            {
                return BadRequest(user.ErrorMessage);

            }
            _newHouse._creationDate = DateTime.UtcNow;

            HttpClient client = new HttpClient();
            var path = BASE_URL + "?"+ $"Date={_newHouse._creationDate:yyyyMMddHHmmss}&Price={_newHouse._currentPrice}&Bedrooms={_newHouse._noOfRooms}&Bathrooms={_newHouse._noOfBathrooms}&Sqft_living={_newHouse._surface}&Sqft_lot={_newHouse._landSurface}&Floors={_newHouse._floor}&View={_newHouse._surface}&Condition={_newHouse._condition}&Grade={_newHouse._grade}&Sqft_basement={_newHouse._sqft_basement}&Yr_built={_newHouse._constructionYear}&Yr_renovated={_newHouse._yr_renovated}&Zipcode={_newHouse._zipcode}&Lat={_newHouse._latitude}&Long={_newHouse._longitude}";
            HttpResponseMessage response = await client.GetAsync(path);

            RecommendedPrice prices = new RecommendedPrice();
            if(response.IsSuccessStatusCode)
            {
                prices = await response.Content.ReadAsAsync<RecommendedPrice>();
                _newHouse._recommendedSellPrice = prices.sell_price;
                _newHouse._recommendedRentPrice = prices.rent_price;
            }
            var house = await _service.CreateHouseAsync(_newHouse);
            if (house.IsSuccess)
            {
                await _userService.AddHouseAsync(user.User, _newHouse);
                return Ok(prices);
            }

            return BadRequest(house.ErrorMessage);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetHousesAsync()
        {
            var houses = await _service.GetHousesAsync();
            if (houses.IsSuccess)
            {
                return Ok(houses.Houses);
            }

            return NotFound(houses.ErrorMessage);
        }

        [HttpGet("recommended")]
        public async Task<IActionResult> GetRecommendedHousesAsync()
        {
            var houses = await _service.GetRecommendedHousesAsync();
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

        //houses?_currentPrice=a&_noOfRooms=b&_noOfBathrooms=c&_surface=d&_floor=e
        [HttpGet]
        public async Task<IActionResult> GetHousesByAsync(string currentPrice, string noOfRooms, string noOfBathrooms, string surface, string floor)
        {
            var filters = new Dictionary<string, float>();
            if(string.IsNullOrEmpty(currentPrice))
            {
                filters.Add("_currentPrice", float.Parse(currentPrice));
            }
            if(string.IsNullOrEmpty(noOfRooms))
            {
                filters.Add("_noOfRooms", float.Parse(noOfRooms));
            }
            if(string.IsNullOrEmpty(noOfBathrooms))
            {
                filters.Add("_noOfBathrooms", float.Parse(noOfBathrooms));
            }
            if(string.IsNullOrEmpty(surface))
            {
                filters.Add("_surface", float.Parse(surface));
            }
            if(string.IsNullOrEmpty(floor))
            {
                filters.Add("_floor", float.Parse(floor));
            }

            var houses = await _service.GetHousesByFiltersAsync(filters);

            if (houses.IsSuccess)
            {
                return Ok(houses.House);
            }

            return NotFound(houses.ErrorMessage);
        }
    }
}
