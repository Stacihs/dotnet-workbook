using System.Collections.Generic;

namespace ESpecies.Models
{
    public class Species
    {
        public int EntityId { get; set; }
        public string SciName { get; set; }
        public string ComName { get; set; }
        public int StatusId { get; set; }
        public string SpCode { get; set; }
        public string VipCode { get; set; }
        public string PopAbbrev { get; set; }
        public string PopDesc { get; set; }
        public string TSN { get; set; }
        public string CountryId { get; set; }
        public int ListingDate { get; set; }
        public string Description { get; set; }
        public string SponsorId { get; set; }
        
        public virtual ICollection<Donation> Donation { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
   
    }
}
