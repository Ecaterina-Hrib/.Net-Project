using HousePricePrediction.API.Users.DB;

namespace HousePricePrediction.API.Users.Infrastructure
{
    public static class UserFactory
    {
        public static UsersDbContext SeedUsers(this UsersDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Id = new Guid("3aa28481-455f-46ce-838d-06f69547ea7d")
                });
                context.Users.Add(new User
                {
                    Id = new Guid("52eb3859-5391-49cc-a7b5-a9ff95f47f88")
                });
                context.SaveChanges();
            }
            return context;
        }
    }
}
