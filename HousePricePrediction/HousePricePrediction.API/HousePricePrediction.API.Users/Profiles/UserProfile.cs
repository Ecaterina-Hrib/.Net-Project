using HousePricePrediction.API.Users.DB;
using HousePricePrediction.API.Users.Model;

namespace HousePricePrediction.API.Users.Profiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
