namespace HousePricePrediction.API.Houses.Model
{
    public class HouseModel
    {
        private Guid Id { get; set; }
        private long userID { get; set; }
        private String? description { get; set; }
        private String? title { get; set; }
        private String? city { get; set; }
        private String? country { get; set; }
        private String? address { get; set; }
        private String? area { get; set; }
        private Double latitude { get; set; }
        private Double longitude { get; set; }
        private int constructionYear { get; set; }
        private int noOfRooms { get; set; }
        private int floor { get; set; }
        private int surface { get; set; }
        private int landSurface { get; set; }
        private int noOfBathrooms { get; set; }
        private int houseType { get; set; }
        private int sellType { get; set; }
        private Dictionary<DateTime, Double> priceHistory { get; set; }  = new Dictionary<DateTime, Double>();
        private Dictionary<DateTime, int> favoriteHistory { get; set; } = new Dictionary<DateTime, int>();
        private int noOfFave { get; set; } = 0;
        private Double recommendedPrice { get; set; }
        private Double currentPrice { get; set; }
        private DateTime creationDate { get; set; }
        private Dictionary<DateTime, int> viewsHistory { get; set; } = new Dictionary<DateTime, int>();
        private int views { get; set; }
        private ICollection<String>? pictures { get; set; }
    }
}
