using FII.eCommerce.Api.Customers.DB;
using FII.eCommerce.Api.Customers.Models;

namespace FII.eCommerce.Api.Customers.Profiles
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerModel>();
        }
    }
}
