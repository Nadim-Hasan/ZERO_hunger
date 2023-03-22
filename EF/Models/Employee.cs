using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZERO_hunger.EF.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string location { get; set; }
        public virtual ICollection<DonationDetail> DontationDetails { get; set; }
        public Employee()
        {
            DontationDetails = new List<DonationDetail>();
        }
    }
}