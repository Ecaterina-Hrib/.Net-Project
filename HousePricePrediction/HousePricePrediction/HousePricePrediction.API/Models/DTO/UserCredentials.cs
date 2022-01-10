using System.ComponentModel.DataAnnotations.Schema;

namespace HousePricePrediction.API.Models
{
    [NotMapped]
    public class UserCredentials
    {
        public String _email { get; set; } = "";
        public String _password { get; set; } = "";
    }
}