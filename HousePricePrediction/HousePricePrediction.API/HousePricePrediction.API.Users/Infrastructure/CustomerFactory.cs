using FII.eCommerce.Api.Customers.DB;

namespace FII.eCommerce.Api.Customers.Infrastructure
{
    public static class CustomerFactory
    {
        public static CustomersDbContext SeedCustomers(this CustomersDbContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer
                {
                    Id = new Guid("3aa28481-455f-46ce-838d-06f69547ea7d"),
                    Name = "John Doe",
                    Address = "20 Elm St."
                });
                context.Customers.Add(new Customer
                {
                    Id = new Guid("52eb3859-5391-49cc-a7b5-a9ff95f47f88"),
                    Name = "Jessica Smith",
                    Address = "30 Elm St."
                });
                context.SaveChanges();
            }
            return context;
        }
    }
}
