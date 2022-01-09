using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HousePricePrediction.API.Domain.Common;

namespace HousePricePrediction.API.Entities
{
    [Table("houses")]
    public class House : BaseEntity
    { 
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid _id { get; set; }
        public User? _user { get; set; }
        public String? _description { get; set; }
        public String? _title { get; set; }
        public String? _city { get; set; }
        public String? _country { get; set; }
        public String? _address { get; set; }
        public String? _area { get; set; }
        public Double? _latitude { get; set; }
        public Double? _longitude { get; set; }
        public float? _constructionYear { get; set; }
        public float? _noOfRooms { get; set; }
        public float? _floor { get; set; }
        public float? _surface { get; set; }
        public float? _landSurface { get; set; }
        public float? _noOfBathrooms { get; set; }
        public float? _view  { get; set; }
        public float? _condition  { get; set; }
        public float? _grade  { get; set; }
        public float? _sqft_basement  { get; set; }
        public float? _yr_renovated  { get; set; }
        public float? _zipcode  { get; set; }
        public Double? _recommendedPrice { get; set; }
        public Double? _currentPrice { get; set; }
        public DateTime _creationDate { get; set; }
        // public Dictionary<DateTime, int> _viewsHistory { get; set; } = new Dictionary<DateTime, int>();
        // public Dictionary<DateTime, Double> _priceHistory { get; set; }  = new Dictionary<DateTime, Double>();
        // public Dictionary<DateTime, int> _favoriteHistory { get; set; } = new Dictionary<DateTime, int>();
        // public int _noOfFave { get; set; } = 0;
        public int _views { get; set; }
        public List<String> _pictures { get; set; } = new List<String>();

    }
}
