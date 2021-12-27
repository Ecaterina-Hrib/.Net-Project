namespace HousePricePrediction.API.Houses.Profiles
{
    public class HouseProfile : AutoMapper.Profile
    {
        public HouseProfile()
        {
            CreateMap<DB.House, Model.HouseModel>().ReverseMap();
        }
    }
}
