
namespace HousePricePrediction.API.Houses.DB
{
    public class House
    { 
        private Guid _id { get; set; }
        private long _userID { get; set; }
        private String? _description { get; set; }
        private String? _title { get; set; }
        private String? _city { get; set; }
        private String? _country { get; set; }
        private String? _address { get; set; }
        private String? _area { get; set; }
        private Double _latitude { get; set; }
        private Double _longitude { get; set; }
        private int _constructionYear { get; set; }
        private int _noOfRooms { get; set; }
        private int _floor { get; set; }
        private int _surface { get; set; }
        private int _landSurface { get; set; }
        private int _noOfBathrooms { get; set; }
        private int _houseType { get; set; }
        private int _sellType { get; set; }
        private Dictionary<DateTime, Double> _priceHistory { get; set; }  = new Dictionary<DateTime, Double>();
        private Dictionary<DateTime, int> _favoriteHistory { get; set; } = new Dictionary<DateTime, int>();
        private int _noOfFave { get; set; } = 0;
        private Double _recommendedPrice { get; set; }
        private Double _currentPrice { get; set; }
        private DateTime _creationDate { get; set; }
        private Dictionary<DateTime, int> _viewsHistory { get; set; } = new Dictionary<DateTime, int>();
        private int _views { get; set; }
        private List<String> _pictures { get; set; } = new List<String>();

        // attributes to estimate the price (ML module)
        private string Date { get; set; }
        private float Price  { get; set; }
        private float Bedrooms  { get; set; } 
        private float Bathrooms  { get; set; }
        private float Sqft_living  { get; set; }
        private float Sqft_lot  { get; set; }
        private float Floors  { get; set; }
        private float View  { get; set; }
        private float Condition  { get; set; }
        private float Grade  { get; set; }
        private float Sqft_basement  { get; set; }
        private float Yr_built  { get; set; }
        private float Yr_renovated  { get; set; }
        private float Zipcode  { get; set; }
        private float Lat  { get; set; }
        private float Long  { get; set; }
    }
}
