using HousePricePrediction.API.Controllers;
using HousePricePrediction.API.Entities;
using HousePricePrediction.API.Persistence.Repository;
using HousePricePrediction.API.Tests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

// TODO: tests for each method from house controller (positive and negative flow).

namespace HousePricePrediction.API.Tests
{
    [Collection("Sequential")]
    public class HousesControllerTest : DatabaseBaseTest
    {
        private readonly HousesController? _housesController;

        
        public HousesControllerTest()
        {
            Repository<House> houseRepository = new(dataContext);
            _housesController = new HouseController(houseRepository);
        }

    }
}