using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZERO_hunger.EF.Models
{
    public class NGO
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string Pass { get; set; }
    }
}