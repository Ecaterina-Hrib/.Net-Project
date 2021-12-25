using AutoMapper;
using FII.eCommerce.Api.Customers.DB;
using FII.eCommerce.Api.Customers.Infrastructure;
using FII.eCommerce.Api.Customers.Interfaces;
using FII.eCommerce.Api.Customers.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FII.eCommerce.Api.Customers.Providers
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly CustomersDbContext context;
        private readonly ILogger<CustomersProvider> logger;
        private readonly IMapper mapper;

        public CustomersProvider(CustomersDbContext context, ILogger<CustomersProvider> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            context.SeedCustomers();
        }

        public async Task<(bool IsSuccess, CustomerModel Customer, string ErrorMessage)> GetCustomerAsync(Guid id)
        {
            try
            {
                logger?.LogInformation("Quering customer by its id");
                var customer = await context.Customers.SingleOrDefaultAsync(c => c.Id == id);
                if (customer != null)
                {
                    logger?.LogInformation("Customer found");
                    var result = mapper.Map<Customer, CustomerModel>(customer);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<CustomerModel> Customers, string ErrorMessage)> GetCustomersAsync()
        {
            try
            {
                logger?.LogInformation("Quering customers");
                var customers = await context.Customers.ToListAsync();

                if (customers != null && customers.Any())
                {
                    logger?.LogInformation($"{customers.Count} customer(s) found");
                    var result = mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerModel>>(customers);
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
