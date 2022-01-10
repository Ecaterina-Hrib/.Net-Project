using System.ComponentModel.DataAnnotations.Schema;

namespace HousePricePrediction.API.Models
{
    [NotMapped]
    public class RecommendedPrice
    {
        public float sell_price { get; set; }
        public float rent_price { get; set; }
    }
}