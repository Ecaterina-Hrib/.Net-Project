// using HousePricePrediction.API.Houses.DB;
// using HousePricePrediction.API.Houses.Interfaces;
// using HousePricePrediction.API.Houses.Providers;
// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// // project dependecies
// builder.Services.AddScoped<IHousesProvider, HousesProvider>();
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// builder.Services.AddDbContext<HouseDbContext>( options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseAuthorization();

// app.MapControllers();

// app.Run();

namespace HousePricePrediction.API
{
       public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    // webBuilder.UseUrls("http://*:" + Environment.GetEnvironmentVariable("PORT")); 
                });
    }
}
