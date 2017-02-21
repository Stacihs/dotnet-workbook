using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ESpecies.Models
{
    public class Cart
    {
        public int TransactionID { get; set; }
        [Display (Name = Donation Amount)] 
        public decimal Amount { get; set; } 
        
        public virtual Sponsor Sponsor { get; set; }
        public virtual ICollection<Species> Species { get; set; }   

         

    }
}
