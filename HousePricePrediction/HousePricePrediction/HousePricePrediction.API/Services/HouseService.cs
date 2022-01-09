using HousePricePrediction.API.DB;
using HousePricePrediction.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace HousePricePrediction.API.Services
{
    public class HouseService
    {
        private readonly DatabaseContext context;

        private readonly IConfiguration configuration;
        private readonly ILogger<HouseService> logger;

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
                    // var result = mapper.Map<HouseModel>(house);
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
                    // var result = mapper.Map<HouseModel>(house);
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
                    // logger?.LogInformation($"{houses.Count} house(s) found");

                    // var result = mapper.Map<IEnumerable<HouseModel>>(houses);
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
    }
}
