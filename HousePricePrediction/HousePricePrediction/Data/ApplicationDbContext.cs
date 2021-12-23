using HousePricePrediction.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousePricePrediction.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext (DbContextOptions<ApplicationDbContext > options) : base(options){}
        
        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
        /*
            TO DO
        */
        }
    }
}
