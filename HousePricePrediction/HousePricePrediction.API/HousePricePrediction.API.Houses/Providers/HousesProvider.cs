using AutoMapper;
using HousePricePrediction.API.Houses.DB;
using HousePricePrediction.API.Houses.Infrastracture;
using HousePricePrediction.API.Houses.Interfaces;
using HousePricePrediction.API.Houses.Model;
using Microsoft.EntityFrameworkCore;

namespace HousePricePrediction.API.Houses.Providers
{
    public class HousesProvider : IHousesProvider
    {
        private readonly HouseDbContext context;
        private readonly ILogger<HousesProvider> logger;
        private readonly IMapper mapper;

        public HousesProvider(HouseDbContext context, ILogger<HousesProvider> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            context.SeedHouses();
        }

        public async Task<(bool IsSuccess, HouseModel House, string ErrorMessage)> GetHouseAsync(Guid id)
        {
            try
            {
                logger?.LogInformation("Quering houses");
                var house = await context.Houses.FirstOrDefaultAsync(p=>p.Id == id);
                if (house != null)
                {
                    var result = mapper.Map<HouseModel>(house);
                    return (true, result, null);
                }

                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<HouseModel> Houses, string ErrorMessage)> GetHousesAsync()
        {
            try
            {
                logger?.LogInformation("Quering houses");
                var houses = await context.Houses.ToListAsync();
                if (houses != null && houses.Any())
                {
                    logger?.LogInformation($"{houses.Count} house(s) found");

                    var result = mapper.Map<IEnumerable<HouseModel>>(houses);
                    return (true, result, null);
                }

                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
