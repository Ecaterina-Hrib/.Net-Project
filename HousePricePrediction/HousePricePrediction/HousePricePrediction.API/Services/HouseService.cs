using HousePricePrediction.API.DB;
using HousePricePrediction.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System;


namespace HousePricePrediction.API.Services
{
    public class HouseService
    {
        private readonly DatabaseContext context;

        private readonly IConfiguration configuration;
        private readonly ILogger<HouseService> logger;

        private const int RECOMMENDED_HOUSES_ITEMS = 10;

        public HouseService(DatabaseContext context, IConfiguration configuration, ILogger<HouseService> logger)
        {
            this.context = context;
            this.configuration =  configuration;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, House House, string ErrorMessage)> CreateHouseAsync(House _newHouse)
        {
            try
            {
                logger?.LogInformation("Create a house");
                var house = await context.Houses.AddAsync(_newHouse);
                if (house != null)
                {
                    await context.SaveChangesAsync();
                    return (true, house.Entity, "created!");
                }

                return (false, new House(), "Did not save");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, new House(), ex.Message);
            }
        }
        public async Task<(bool IsSuccess, House House, string ErrorMessage)> GetHouseAsync(Guid id)
        {
            try
            {
                logger?.LogInformation("Quering houses");
                var house = await context.Houses.FirstOrDefaultAsync(p=>p._id == id);
                if (house != null)
                {
                    house._views++;
                    var user = await context.Users.FirstOrDefaultAsync(u=>u._id == house._user_id);
                    user._totalViews++;
                    house._user = user;
                    await context.SaveChangesAsync();
                    return (true, house, "");
                }

                return (false, new House(), "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, new House(), ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<House> Houses, string ErrorMessage)> GetHousesAsync()
        {
            try
            {
                logger?.LogInformation("Quering houses");
                var houses = await context.Houses.ToListAsync();
                if (houses != null && houses.Any())
                {
                    return (true, houses, "null");
                }

                return (false, Enumerable.Empty<House>(), "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, Enumerable.Empty<House>(), ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<House> Houses, string ErrorMessage)> FilterHousesAsync(float bathrooms, float rooms, float price, float surface, float floors)
        {
            try
            {
                logger?.LogInformation("Quering houses");
                var houses = await context.Houses.ToListAsync();
                if (houses != null && houses.Any())
                {
                    var filteredHouses = houses.Where(h => (h._noOfBathrooms == bathrooms && h._noOfRooms == rooms && h._currentPrice <= price && h._surface >= surface && h._floor == floors));
                    return (true, filteredHouses, "filter");
                }

                return (false, Enumerable.Empty<House>(), "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, Enumerable.Empty<House>(), ex.Message);
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<House> Houses, string ErrorMessage)> GetRecommendedHousesAsync()
        {
            try
            {
                logger?.LogInformation("Quering houses");
                var houses = await context.Houses.ToListAsync();
                if (houses != null && houses.Any())
                {
                    var numberOfItems = Math.Min(RECOMMENDED_HOUSES_ITEMS, houses.Count());
                    return (true, houses.OrderByDescending(h => (h._recommendedSellPrice/h._currentPrice*100)).Take(numberOfItems), "Recommended houses");
                }

                return (false, Enumerable.Empty<House>(), "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, Enumerable.Empty<House>(), ex.Message);
            }
        }
    }
}
