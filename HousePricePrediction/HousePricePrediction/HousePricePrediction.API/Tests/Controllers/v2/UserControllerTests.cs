using Microsoft.AspNetCore.Mvc;
using HousePricePrediction.API.Tests;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;

namespace HousePricePrediction.API.Tests
{
    public class UserControllerTests : DatabaseBaseTest
    {
        [Fact]
        public async Task foundUser()
        {
            using var client = new HttpClient();
            var user = await client.GetStringAsync("http://localhost:5075/api/v1/users/0e937846-8bd4-49eb-94bd-029fbcb725d8");
            Assert.NotEmpty(user);
        }

        [Fact]
        public async Task notFoundUser()
        {
            using var client = new HttpClient();
            var user = await client.GetStringAsync("http://localhost:5075/api/v1/users/0e937846-8bd4-49eb-94bd-029fbcb725d78");
            Assert.IsType<NotFoundObjectResult>(user);
        }

        [Fact]
        public async Task foundUsers()
        {
            using var client = new HttpClient();
            var users = await client.GetStringAsync("http://localhost:5075/api/v1/users");
            Assert.NotEmpty(users);
        }
    }
}