using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;
using HousePricePrediction.API.Houses.Providers;
using HousePricePrediction.API.Houses.DB;
using HousePricePrediction.API.Houses.Interfaces;
using Microsoft.EntityFrameworkCore.Design;


namespace HousePricePrediction.API.Houses
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHousesProvider, HousesProvider>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "House Price Predictionx", Version = "v1" });

                c.IncludeXmlComments(
                    Path.Combine(
                        AppContext.BaseDirectory,
                        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"
                    )
                );
            });

            services.AddDbContext<HouseDbContext>(options =>
                options
                    .UseNpgsql(Configuration.GetConnectionString("HouseDbContext"))
                    .UseSnakeCaseNamingConvention()
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                    .EnableSensitiveDataLogging()
            );

            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehicleQuotes v1");
                c.RoutePrefix = "";
            });
            // }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}