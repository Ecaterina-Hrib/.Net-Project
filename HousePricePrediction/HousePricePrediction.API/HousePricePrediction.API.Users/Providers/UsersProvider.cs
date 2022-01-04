using AutoMapper;
using HousePricePrediction.API.Users.DB;
using HousePricePrediction.API.Users.Infrastructure;
using HousePricePrediction.API.Users.Interfaces;
using HousePricePrediction.API.Users.Model;
using Microsoft.EntityFrameworkCore;

namespace HousePricePrediction.API.Users.Providers
{
    public class UsersProvider : IUsersProvider
    {
        private readonly UsersDbContext context;
        private readonly ILogger<UsersProvider> logger;
        private readonly IMapper mapper;

        public UsersProvider(UsersDbContext context, ILogger<UsersProvider> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            context.SeedUsers();
        }

        public async Task<(bool IsSuccess, UserModel User, string ErrorMessage)> GetUserAsync(Guid id)
        {
            try
            {
                logger?.LogInformation("Quering user by its id");
                var user = await context.Users.SingleOrDefaultAsync(c => c.Id == id);
                if (user != null)
                {
                    logger?.LogInformation("User found");
                    var result = mapper.Map<User, UserModel>(user);
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

        public async Task<(bool IsSuccess, IEnumerable<UserModel> Users, string ErrorMessage)> GetUsersAsync()
        {
            try
            {
                logger?.LogInformation("Quering users");
                var users = await context.Users.ToListAsync();

                if (users != null && users.Any())
                {
                    logger?.LogInformation($"{users.Count} user(s) found");
                    var result = mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);
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
