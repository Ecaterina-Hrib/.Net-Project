using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousePrice.Model;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {
        [HttpGet]
        public Output Get(string Date, float Price, float Bedrooms, float Bathrooms, float Sqft_living, float Sqft_lot, float Floors, float View, float Condition, float Grade, float Sqft_basement, float Yr_built, float Yr_renovated, float Zipcode, float Lat, float Long)
        {
            HousePrice.Model.ModelInput InputData = new ModelInput(){
                Date = Date,
                Price = Price,
                Bedrooms = Bedrooms,
                Bathrooms = Bathrooms,
                Sqft_living = Sqft_living,
                Sqft_lot =Sqft_lot,
                Sqft_basement = Sqft_basement,
                Floors = Floors,
                View = View,
                Condition = Condition,
                Grade = Grade,
                Yr_built = Yr_built,
                Yr_renovated = Yr_renovated,
                Zipcode = Zipcode,
                Lat = Lat,
                Long = Long

            };
            float price_generated = HousePrice.Model.ConsumeModel.SendPredictedPrice(InputData);
            Output OutputProperty = new Output()
            {
                sell_price = price_generated,
                rent_price = 0.0065F* price_generated
            };

            return OutputProperty;
        }
    }
}

