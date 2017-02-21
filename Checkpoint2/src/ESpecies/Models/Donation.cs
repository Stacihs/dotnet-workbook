using System.Collections.Generic;

namespace ESpecies.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string SponsorName { get; set; } 
        public string Species { get; set; } 

        public virtual ICollection<Sponsor> Sponsor { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
