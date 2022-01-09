using HousePricePrediction.API.DB;
using HousePricePrediction.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HousePricePrediction.API.Services
{
    public class UserService
    {
        private readonly DatabaseContext context;

        private readonly IConfiguration configuration;
        private readonly ILogger<UserService> logger;

        public UserService(DatabaseContext context, IConfiguration configuration, ILogger<UserService> logger)
        {
            this.context = context;
            this.configuration =  configuration;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, User User, string ErrorMessage)> CreateUserAsync(User _newUser)
        {
            try
            {
                logger?.LogInformation("Create a user");
                var user = await context.Users.AddAsync(_newUser);
                if (user != null)
                {
                    // var result = mapper.Map<HouseModel>(house);
                    await context.SaveChangesAsync();
                    return (true, user.Entity, "created!");
                }

                return (false, new User(), "Did not save");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, new User(), ex.Message);
            }
        }
        public async Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserAsync(Guid id)
        {
            try
            {
                logger?.LogInformation("Quering user by its id");
                var user = await context.Users.SingleOrDefaultAsync(c => c._id == id);
                if (user != null)
                {
                    logger?.LogInformation("User found");
                    // var result = mapper.Map<User, UserModel>(user);
                    return (true, user, "null");
                }
                return (false, new User(), "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, new User(), ex.Message);
            }
        }

        public async Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserByUsernameAsync(string username)
        {
            try
            {
                logger?.LogInformation("Quering user by its username");
                var user = await context.Users.SingleOrDefaultAsync(c => c._username == username);
                if (user != null)
                {
                    logger?.LogInformation("User found");
                    // var result = mapper.Map<User, UserModel>(user);
                    return (true, user, "null");
                }
                return (false, new User(), "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, new User(), ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<User> Users, string ErrorMessage)> GetUsersAsync()
        {
            try
            {
                logger?.LogInformation("Quering users");
                var users = await context.Users.ToListAsync();

                if (users != null && users.Any())
                {
                    logger?.LogInformation($"{users.Count} user(s) found");
                    // var result = mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);
                    return (true, users, "null");
                }
                return (false, Enumerable.Empty<User>(), "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, Enumerable.Empty<User>(), ex.Message);
            }
        }
    }
}
