using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZERO_hunger.EF.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Donation> Dontations { get; set; }
        public Restaurant()
        {
            Dontations = new List<Donation>();
        }
    }
}