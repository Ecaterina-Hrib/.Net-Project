using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HousePricePrediction.API.Houses.DB
{
    public class House
    { 
        public Guid _id { get; set; }
        public long _userID { get; set; }
        public String? _description { get; set; }
        public String? _title { get; set; }
        public String? _city { get; set; }
        public String? _country { get; set; }
        public String? _address { get; set; }
        public String? _area { get; set; }
        public Double _latitude { get; set; }
        public Double _longitude { get; set; }
        public int _constructionYear { get; set; }
        public int _noOfRooms { get; set; }
        public int _floor { get; set; }
        public int _surface { get; set; }
        public int _landSurface { get; set; }
        public int _noOfBathrooms { get; set; }
        public int _houseType { get; set; }
        public int _sellType { get; set; }
        public Dictionary<DateTime, Double> _priceHistory { get; set; }  = new Dictionary<DateTime, Double>();
        public Dictionary<DateTime, int> _favoriteHistory { get; set; } = new Dictionary<DateTime, int>();
        public int _noOfFave { get; set; } = 0;
        public Double _recommendedPrice { get; set; }
        public Double _currentPrice { get; set; }
        public DateTime _creationDate { get; set; }
        public Dictionary<DateTime, int> _viewsHistory { get; set; } = new Dictionary<DateTime, int>();
        public int _views { get; set; }
        public List<String> _pictures { get; set; } = new List<String>();

        // attributes to estimate the price (ML module)
        public string ? Date { get; set; }
        public float Price  { get; set; }
        public float Bedrooms  { get; set; } 
        public float Bathrooms  { get; set; }
        public float Sqft_living  { get; set; }
        public float Sqft_lot  { get; set; }
        public float Floors  { get; set; }
        public float View  { get; set; }
        public float Condition  { get; set; }
        public float Grade  { get; set; }
        public float Sqft_basement  { get; set; }
        public float Yr_built  { get; set; }
        public float Yr_renovated  { get; set; }
        public float Zipcode  { get; set; }
        public float Lat  { get; set; }
        public float Long  { get; set; }
    }
}
