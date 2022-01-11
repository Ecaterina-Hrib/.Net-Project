﻿using HousePricePrediction.API.DB;
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

        public async Task<(bool IsSuccess, IEnumerable<House> Houses, string ErrorMessage)> GetHousesByFiltersAsync(var Filters)
        {
             try
            {
                logger?.LogInformation("Quering houses");

                var query = context.Houses;

                foreach(var filter in Filters)
                    query = query.Where(filter.PropertyName, filter.Value);

                var houses = query.FirstOrDefault<House>();

                if (houses != null)
                {
                    await context.SaveChangesAsync();
                    return (true, houses, "");
                }

                return (false, Enumerable.Empty<House>(), "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, Enumerable.Empty<House>(), ex.Message);
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
