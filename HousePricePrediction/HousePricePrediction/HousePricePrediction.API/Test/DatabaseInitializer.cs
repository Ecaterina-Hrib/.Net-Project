using HousePricePrediction.API.Entities;
using HousePricePrediction.API.Persitence.Context;
using System.Collections.Generic;
using System;

namespace Test
{
    public class DatabaseInitializer
    {
        private static readonly object lockMethod = new();

        public static void Initialize(DatabaseContext dataContext)
        {
            lock (lockMethod)
            {
                if (dataContext.Houses == null || dataContext.Users == null)
                {
                    return;
                }

                Seed(dataContext);
            }
        }

        private static void Seed(DatabaseContext dataContext)
        {
            SeedUsers(dataContext);
            SeedHouses(dataContext);
        }

        private static void SeedUsers(DatabaseContext dataContext)
        {
            List<House> list = new List<House>();
            var users = new[] {
                new User { _id = Guid.NewGuid(), _name = "Andrei Tiriac", _phoneNumber = "0767636092", _username = "tandrei", _email = "tandrei@gmail.com", _password = "password", _creationDate = new DateTime(2015, 12, 25), _forSell = list },
                new User { _id = Guid.NewGuid(), _name = "Maria Ionescu", _phoneNumber = "0788636092", _username = "imaria", _email = "imaria@gmail.com", _password = "something", _creationDate = new DateTime(2010, 12, 25), _forSell = list }
            };

            dataContext.AddRange(users);
            dataContext.SaveChanges();
        }

         private static void SeedHouses(DatabaseContext dataContext)
        {
            List<House> list = new List<House>();
            User user = new() { _id = Guid.NewGuid(), _name = "Andrei Tiriac", _phoneNumber = "0767636092", _username = "tandrei", _email = "tandrei@gmail.com", _password = "password", _creationDate = new DateTime(2015, 12, 25), _forSell = list };
            List<String> pictureList = new List<String>();
            pictureList.Add("https://www.google.com/search?q=beach+house&sxsrf=AOaemvJ7gLYfg0qCo83M37cx8b-TSHIQoA:1641719240384&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjg45LhqKT1AhWOLOwKHbOaAMQQ_AUoAXoECAIQAw&biw=1536&bih=714&dpr=1.25#imgrc=uMDMbcc4HgWskM");
           
            var houses = new[] {
              new House { _id = Guid.NewGuid(), _user = user, _description = "tell me more", _title = "Beach house", _city = "Constanta", _country = "Romania", _address = "Str Sf Lazar", _area = "something", _latitude = 2256, _longitude = 4673, _constructionYear = 1980, _noOfRooms = 5, _floor = 2, _surface = 1, _landSurface = 4, _noOfBathrooms = 2, _view = 9,  _condition = 8, _grade = 8, _sqft_basement = 2, _yr_renovated = 2012, _zipcode = 50093, _recommendedPrice = 456000, _currentPrice = 700000, _creationDate =  new DateTime(2015, 12, 25), _views = 9, _pictures = pictureList}
            };

            dataContext.AddRange(houses);
            dataContext.SaveChanges();
        }

    }
}