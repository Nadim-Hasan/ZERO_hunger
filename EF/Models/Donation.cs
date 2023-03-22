using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZERO_hunger.EF.Models
{
    public class Donation
    {

       
       
        [Key]
        public int Id { get; set; }
        public string FoodName { get; set; }
      //  [ForeignKey("Restaurant")]
        //public int ResId { get; set; } 

        public int RId { get; set; }
        public string Status { get; set; }
        public int Validity { get; set; }
        public virtual ICollection <DonationDetail> DontationDetails { get; set; }
        public Donation()
        {
            DontationDetails = new List<DonationDetail>();
        }
        public virtual Restaurant Restaurant { get; set; }

    }
}