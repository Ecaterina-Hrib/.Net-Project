using HousePricePrediction.API.Entities;
using System;
using System.Threading.Tasks;
using HousePricePrediction.API.Interfaces;

namespace HousePricePrediction.API.Interfaces
{
    public interface IHouseRepository : IRepository<House>
    {
        Task<House> GetHouseByIdAsync(Guid id);
    }
}
