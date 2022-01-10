using HousePricePrediction.API.Controllers;
using HousePricePrediction.API.Models;
using HousePricePrediction.API.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HousePricePrediction.API.Tests.v1
{
    [Collection("Sequential")]
    public class HousesControllerTest : DatabaseBaseTest
    {
        private readonly HousesController? _housesController;
        private readonly IConfiguration configuration;
        private readonly ILogger<HouseService> houseLogger;

        private readonly ILogger<UserService> userLogger;
        
        public HousesControllerTest()
        {
            HouseService houseService = new(dataContext, configuration, houseLogger);
            UserService userService = new(dataContext, configuration, userLogger);
            _housesController = new HousesController(houseService, userService);
        }

          [Fact]
        public async void GetHouses_ShouldReturn_Ok()
        {
             // Act
            ActionResult<House> actionResult = await _housesController.GetHousesAsync();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void GetHouseBy_Generated_Id_ShouldReturn_NotFound()
        {
            //Arrange
            Guid id = Guid.Parse("f7cb8e84-b440-4b6f-886e-496cc5dc3ccd");

            // Act
            ActionResult<House> actionResult = await _housesController.GetHouseAsync(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void GetHouseById_ShouldReturn_Ok()
        {
            //Arrange
            Guid id = Guid.Parse("154b9350-ccef-4ab1-aa7a-9eddc0b3cd6a");

            // Act
            ActionResult<House> actionResult = await _housesController.GetHouseAsync(id);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Create_Null_House_ShouldReturn_BadRequest()
        {
            //Arrange
            House house = null;

            // Act
            ActionResult<House> actionResult = await _housesController.CreateHouseAsync("house", house);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Create_New_House_ShouldReturn_CreatedAtAction()
        {
            //Arrange
            House house = new()
            {
                _address = "Address"
            };

            // Act
            ActionResult<House> actionResult = await _housesController.CreateHouseAsync("house1", house);

            // Assert
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        }
    }
}