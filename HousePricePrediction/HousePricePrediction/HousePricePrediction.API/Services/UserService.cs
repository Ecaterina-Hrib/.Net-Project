using HousePricePrediction.API.DB;
using HousePricePrediction.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Effortless.Net.Encryption;

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
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, User User, string ErrorMessage)> CreateUserAsync(User _newUser)
        {
            try
            {
                logger?.LogInformation("Create a user");
                var password = _newUser._password;
                var key = Bytes.GenerateKey();
                var iv = Bytes.GenerateIV();
                _newUser._password = Strings.Encrypt(password, key, iv);
                _newUser.key = key;
                _newUser.iv = iv;
                var user = await context.Users.AddAsync(_newUser);
                if (user != null)
                {
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
        public async Task<(bool IsSuccess, Guid Id, string ErrorMessage)> Login(string email, string password)
        {
            try
            {
                logger?.LogInformation("Trying to login...");
                var user = await context.Users.SingleOrDefaultAsync(c => c._email== email);
                if (user != null)
                {
                    logger?.LogInformation("Email exists");
                    // Console.WriteLine(user._password);
                    // Console.WriteLine(password);
                    // Console.WriteLine(Strings.Decrypt(user._password, key, iv));


                    if(Strings.Decrypt(user._password, user.key, user.iv).Equals(password))
                    {
                        return (true, user._id, "Correct credentials!");
                    }
                    
                    return (false, new Guid(), "Wrong password!");

                }
                return (false, new Guid(), "Email Not Found");

            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, new Guid(), ex.Message);
            }
        }
        // public async Task<(bool IsSuccess, User User, string ErrorMessage)> AddHouseAsync(User userData, House house)
        // {
        //     try
        //     {
        //         logger?.LogInformation("Add house to user");
        //         var user = await context.Users.SingleOrDefaultAsync(c => c._id == userData._id);
        //         if (user != null)
        //         {
        //             logger?.LogInformation("User found");
        //             user._forSell.Add(house);
        //             await context.SaveChangesAsync();
        //             return (true, user, "added!");


        //         }
        //         return (false, new User(), "Not Found");
        //     }
        //     catch (Exception ex)
        //     {
        //         logger?.LogError(ex.ToString());
        //         return (false, new User(), ex.Message);
        //     }
        // }
        public async Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserAsync(Guid id)
        {
            try
            {
                logger?.LogInformation("Quering user by its id");
                var user = await context.Users.SingleOrDefaultAsync(c => c._id == id);
                if (user != null)
                {
                    logger?.LogInformation("User found");
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
