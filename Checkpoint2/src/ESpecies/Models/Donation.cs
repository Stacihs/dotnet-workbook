using System.Collections.Generic;

namespace ESpecies.Models
{
    public class Donation
    {
        public int ApplicationUserId { get; set; }
        public string Amount { get; set; }
        public string EntityID { get; set; } 

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
