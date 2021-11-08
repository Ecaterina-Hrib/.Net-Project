using System;
using System.Collections.Generic;
using System.Linq;
using HousePricePrediction.Models;

namespace HousePricePrediction.Data
{
    public class HouseRepository : IRepository<House>
    {
        private readonly ApplicationDbContext _context;

        public HouseRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public void Create(House house)
        {
            _context.Add(house);
            _context.SaveChanges();
        }

        public List<House> GetAll() => _context.Houses.ToList();

        public House GetById(System.Type id) => (House)_context.Find(id);

        public void Remove(House house)
        {
            _context.Remove(house);
            _context.SaveChanges();
        }

        public void Update(House house)
        {
            _context.Update(house);
            _context.SaveChanges();
        }
    }
}