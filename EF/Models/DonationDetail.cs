using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZERO_hunger.EF.Models
{
    public class DonationDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Donation")]
        public int DonationId { get; set; }
        public DateTime collectDate { get; set; }
        [ForeignKey("Employee")]
        public int  EmpId { get; set; }
        public virtual Donation Donation { get; set; }
        public virtual Employee Employee { get; set; }


    }
}