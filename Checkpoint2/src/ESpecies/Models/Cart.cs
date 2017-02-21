using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ESpecies.Models
{
    public class Cart
    {
        [Display (Name = "Transaction Number")]
        public int ID { get; set; }
        [Display (Name = "Donation Amount")] 
        public decimal Amount { get; set; } 
        [Display (Name = "Sponsor Name")]
        public string SponsorName { get; set; }
        [Display (Name = "Name of Species")]
        public string SpeciesName { get; set; }


        public virtual Sponsor Sponsor { get; set; }
        public virtual ICollection<Species> Species { get; set; } 
          

    }
}
