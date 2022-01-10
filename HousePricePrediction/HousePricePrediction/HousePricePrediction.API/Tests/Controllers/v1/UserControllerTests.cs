using HousePricePrediction.API.Controllers;
using HousePricePrediction.API.Models;
using HousePricePrediction.API.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HousePricePrediction.API.Tests.v1
{
    [Collection("Sequential")]
    public class UsersControllerTest : DatabaseBaseTest
    {
        private readonly UsersController? _usersController;
        private readonly IConfiguration configuration;
        private readonly ILogger<HouseService> houseLogger;

        private readonly ILogger<UserService> userLogger;
        
        public UsersControllerTest()
        {
            UserService userService = new(dataContext, configuration, userLogger);
            _usersController = new UsersController(userService);
        }

          [Fact]
        public async void GetUsers_ShouldReturn_Ok()
        {
             // Act
            ActionResult<User> actionResult = await _usersController.GetUsersAsync();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void GetUserBy_Generated_Id_ShouldReturn_NotFound()
        {
            //Arrange
            Guid id = Guid.Parse("f7cb8e84-b440-4b6f-886e-496cc5dc3ccd");

            // Act
            ActionResult<User> actionResult = await _usersController.GetUserAsync(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void GetUserById_ShouldReturn_Ok()
        {
            //Arrange
            Guid id = Guid.Parse("154b9350-ccef-4ab1-aa7a-9eddc0b3cd6a");

            // Act
            ActionResult<User> actionResult = await _usersController.GetUserAsync(id);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Create_Null_User_ShouldReturn_BadRequest()
        {
            //Arrange
            User user = null;

            // Act
            ActionResult<User> actionResult = await _usersController.CreateUserAsync(user);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Create_New_User_ShouldReturn_CreatedAtAction()
        {
            //Arrange
            User user = new()
            {
                _name = "antonel"
            };

            // Act
            ActionResult<User> actionResult = await _usersController.CreateUserAsync(user);

            // Assert
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        }
    }
}