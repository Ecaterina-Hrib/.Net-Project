using Microsoft.AspNetCore.Mvc;
using HousePricePrediction.API.Tests;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;

namespace HousePricePrediction.API.Tests
{
    public class HouseControllerTests : DatabaseBaseTest
    {
        [Fact]
        public async Task foundHouse()
        {
            using var client = new HttpClient();
            var house = await client.GetStringAsync("http://localhost:5075/api/v1/houses/0e937846-8bd4-49eb-94bd-029fbcb725d8");
            Assert.NotEmpty(house);
        }

        [Fact]
        public async Task notFoundHouse()
        {
            using var client = new HttpClient();
            var house = await client.GetStringAsync("http://localhost:5075/api/v1/houses/0e937846-8bd4-49eb-94bd-029fbcb725d78");
            Assert.IsType<NotFoundObjectResult>(house);
        }

        [Fact]
        public async Task foundHouses()
        {
            using var client = new HttpClient();
            var houses = await client.GetStringAsync("http://localhost:5075/api/v1/houses");
            Assert.NotEmpty(houses);
        }
    }
}