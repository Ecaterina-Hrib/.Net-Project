using HousePricePrediction.API.Interfaces;
using HousePricePrediction.API.Entities;
using Microsoft.EntityFrameworkCore;
using HousePricePrediction.API.Persitence.Context;
using System;
using System.Threading.Tasks;
using HousePricePrediction.API.Persistence;

namespace HousePricePrediction.API.Persistence.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(user => user._id == id);
        }
    }
}
