using HousePricePrediction.API.Entities;
using System;
using System.Threading.Tasks;
using HousePricePrediction.API.Interfaces;

namespace HousePricePrediction.API.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByIdAsync(Guid id);
    }
}
