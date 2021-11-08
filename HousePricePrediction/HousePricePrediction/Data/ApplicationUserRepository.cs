using System;
using System.Collections.Generic;
using System.Linq;
using HousePricePrediction.Models;
namespace HousePricePrediction.Data
{
    public class ApplicationUserRepository : IRepository<ApplicationUser>
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;

        }

            public void Create(ApplicationUser user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public List<ApplicationUser> GetAll() => _context.Users.ToList();

        public ApplicationUser GetById(System.Type id) => (ApplicationUser)_context.Find(id);

        public void Remove(ApplicationUser user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public void Update(ApplicationUser user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
        
    }
}