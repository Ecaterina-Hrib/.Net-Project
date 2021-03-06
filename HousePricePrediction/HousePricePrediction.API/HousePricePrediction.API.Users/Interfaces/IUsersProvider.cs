using HousePricePrediction.API.Users.Model;

namespace HousePricePrediction.API.Users.Interfaces
{
    public interface IUsersProvider
    {
        Task<(bool IsSuccess, IEnumerable<UserModel> Users, string ErrorMessage)> GetUsersAsync();
        Task<(bool IsSuccess, UserModel User, string ErrorMessage)> GetUserAsync(Guid id);
    }
}
