using HousePricePrediction.API.Interfaces;
using HousePricePrediction.API.Entities;
using Microsoft.EntityFrameworkCore;
using HousePricePrediction.API.Persitence.Context;
using System;
using System.Threading.Tasks;
using HousePricePrediction.API.Persistence;

namespace HousePricePrediction.API.Persistence.Repository
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<House> GetHouseByIdAsync(Guid id)
        {
            return await _context.Houses
                .FirstOrDefaultAsync(house => house._id == id);
        }
    }
}
