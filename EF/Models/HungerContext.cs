using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZERO_hunger.EF.Models
{
    public class HungerContext: DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<DonationDetail> DonationDetails { get; set; }
        public DbSet<NGO> NGOs { get; set; }
        
    }
}