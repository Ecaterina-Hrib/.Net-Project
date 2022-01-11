using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;
using HousePricePrediction.API.Models;
using HousePricePrediction.API.DB;
using HousePricePrediction.API.Services;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;




namespace HousePricePrediction.API
{
    public class Startup
    {   
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<Services.HouseService>();
            services.AddScoped<Services.UserService>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddCors(options =>
            {   
                options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000", "*", "http://localhost:3000/*")
                          .AllowAnyHeader().AllowAnyMethod();
                      });
            });
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "House Price Predictionx", Version = "v1" });

            //     c.IncludeXmlComments(
            //         Path.Combine(
            //             AppContext.BaseDirectory,
            //             $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"
            //         )
            //     );
            // });

            services.AddDbContext<DatabaseContext>(options =>
                options
                    .UseNpgsql(Configuration.GetConnectionString("DatabaseContext"))
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
            app.UseSwaggerUI();
            // }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}