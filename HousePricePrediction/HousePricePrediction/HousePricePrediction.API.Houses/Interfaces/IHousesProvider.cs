namespace HousePricePrediction.API.Houses.Interfaces
{
    public interface IHousesProvider
    {
        Task<(bool IsSuccess, IEnumerable<Model.HouseModel> Houses, string ErrorMessage)> GetHousesAsync();
        Task<(bool IsSuccess,Model.HouseModel House, string ErrorMessage)> GetHouseAsync(Guid id);
    }
}
