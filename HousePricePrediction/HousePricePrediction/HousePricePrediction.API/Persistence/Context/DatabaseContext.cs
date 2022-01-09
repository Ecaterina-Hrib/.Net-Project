using Microsoft.EntityFrameworkCore;
using HousePricePrediction.API.Entities;

namespace HousePricePrediction.API.Persitence.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
                // modelBuilder.Entity<House>()
                // .ToTable("houses");
                // // .HasOne(h => h._user)
                // // .WithMany( u => u._forSell)
                // // .IsRequired()
                // // .HasForeignKey(h => h._id)
                // // .OnDelete(DeleteBehavior.Cascade);

                // modelBuilder.Entity<User>().ToTable("users");

                SetUserProperties(modelBuilder);
                SetHouseProperties(modelBuilder);

                base.OnModelCreating(modelBuilder);
         }

        private static void SetUserProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(o => o._id)
                .HasColumnName("id");
            modelBuilder.Entity<User>()
                .Property(op => op._name)
                .HasColumnName("name");
            modelBuilder.Entity<User>()
                .Property(o => o._phoneNumber)
                .HasColumnName("phone_number");
            modelBuilder.Entity<User>()
                .Property(o => o._username)
                .HasColumnName("username");
            modelBuilder.Entity<User>()
                .Property(o => o._email)
                .HasColumnName("email");
            modelBuilder.Entity<User>()
                .Property(o => o._password)
                .HasColumnName("passwrod");
            modelBuilder.Entity<User>()
                .Property(o => o._creationDate)
                .HasColumnName("creation_date");
            modelBuilder.Entity<User>()
                .Property(o => o._forSell)
                .HasColumnName("for_sell");
            
        }

          private static void SetHouseProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>()
                .Property(o => o._id)
                .HasColumnName("id");
            modelBuilder.Entity<House>()
                .Property(op => op._user)
                .HasColumnName("user");
            modelBuilder.Entity<House>()
                .Property(o => o._description)
                .HasColumnName("description");
            modelBuilder.Entity<House>()
                .Property(o => o._title)
                .HasColumnName("title");
            modelBuilder.Entity<House>()
                .Property(o => o._city)
                .HasColumnName("city");
            modelBuilder.Entity<House>()
                .Property(o => o._country)
                .HasColumnName("country");
            modelBuilder.Entity<House>()
                .Property(o => o._address)
                .HasColumnName("address");
            modelBuilder.Entity<House>()
                .Property(op => op._area)
                .HasColumnName("area");
            modelBuilder.Entity<House>()
                .Property(o => o._latitude)
                .HasColumnName("latitude");
            modelBuilder.Entity<House>()
                .Property(o => o._longitude)
                .HasColumnName("longitude");
            modelBuilder.Entity<House>()
                .Property(o => o._constructionYear)
                .HasColumnName("constructionYear");
            modelBuilder.Entity<House>()
                .Property(o => o._noOfRooms)
                .HasColumnName("noOfRooms");
            modelBuilder.Entity<House>()
                .Property(o => o._floor)
                .HasColumnName("floor");
            modelBuilder.Entity<House>()
                .Property(o => o._surface)
                .HasColumnName("surface");
            modelBuilder.Entity<House>()
                .Property(o => o._landSurface)
                .HasColumnName("landSurface");
            modelBuilder.Entity<House>()
                .Property(o => o._noOfBathrooms)
                .HasColumnName("noOfBathrooms");
            modelBuilder.Entity<House>()
                .Property(o => o._view)
                .HasColumnName("view");
            modelBuilder.Entity<House>()
                .Property(op => op._condition)
                .HasColumnName("condition");
            modelBuilder.Entity<House>()
                .Property(o => o._grade)
                .HasColumnName("grade");
            modelBuilder.Entity<House>()
                .Property(o => o._sqft_basement)
                .HasColumnName("sqft_basement");
            modelBuilder.Entity<House>()
                .Property(o => o._yr_renovated)
                .HasColumnName("yr_renovated");
            modelBuilder.Entity<House>()
                .Property(o => o._zipcode)
                .HasColumnName("zipcode");
            modelBuilder.Entity<House>()
                .Property(o => o._recommendedPrice)
                .HasColumnName("recommendedPrice");
            modelBuilder.Entity<House>()
                .Property(op => op._currentPrice)
                .HasColumnName("currentPrice");
            modelBuilder.Entity<House>()
                .Property(o => o._creationDate)
                .HasColumnName("creationDate");
            modelBuilder.Entity<House>()
                .Property(o => o._views)
                .HasColumnName("views");
            modelBuilder.Entity<House>()
                .Property(o => o._pictures)
                .HasColumnName("pictures");
        }

        private static void SeedUsers(ModelBuilder model)
        {
            var list = new List<House>();
            model.Entity<User>()
                .HasData(
                    new User { _id = Guid.NewGuid(), _name = "Andrei Tiriac", _phoneNumber = "0767636092", _username = "tandrei", _email = "tandrei@gmail.com", _password = "password", _creationDate = new DateTime(2015, 12, 25), _forSell = list },
                    new User { _id = Guid.NewGuid(), _name = "Maria Ionescu", _phoneNumber = "0788636092", _username = "imaria", _email = "imaria@gmail.com", _password = "something", _creationDate = new DateTime(2010, 12, 25), _forSell = list }
                    );
        }

         private static void SeedHouses(ModelBuilder model)
        {
            
            var list = new List<House>();
            User user = new() { _id = Guid.NewGuid(), _name = "Andrei Tiriac", _phoneNumber = "0767636092", _username = "tandrei", _email = "tandrei@gmail.com", _password = "password", _creationDate = new DateTime(2015, 12, 25), _forSell = list };
            var pictureList = new List<String>();
            pictureList.Add("https://www.google.com/search?q=beach+house&sxsrf=AOaemvJ7gLYfg0qCo83M37cx8b-TSHIQoA:1641719240384&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjg45LhqKT1AhWOLOwKHbOaAMQQ_AUoAXoECAIQAw&biw=1536&bih=714&dpr=1.25#imgrc=uMDMbcc4HgWskM");
            model.Entity<House>()
                .HasData(
                    new House { _id = Guid.NewGuid(), _user = user, _description = "tell me more", _title = "Beach house", _city = "Constanta", _country = "Romania", _address = "Str Sf Lazar", _area = "something", _latitude = 2256, _longitude = 4673, _constructionYear = 1980, _noOfRooms = 5, _floor = 2, _surface = 1, _landSurface = 4, _noOfBathrooms = 2, _view = 9,  _condition = 8, _grade = 8, _sqft_basement = 2, _yr_renovated = 2012, _zipcode = 50093, _recommendedPrice = 456000, _currentPrice = 700000, _creationDate =  new DateTime(2015, 12, 25), _views = 9, _pictures = pictureList}
                   );
        }

    }
}
