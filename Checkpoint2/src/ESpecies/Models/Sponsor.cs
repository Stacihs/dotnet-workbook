using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESpecies.Models
{
    public class Sponsor
    {
        [Display (Name = "Sponsor ID")]
        public int Id { get; set; }
        [Display (Name ="First Name")]
        public string FirstName { get; set; }
        [Display (Name = "Last Name")]
        public string LastName { get; set; }
        [Display (Name = "Donation Amount")]
        public decimal DonationAmount { get; set; }
        [Display (Name = "Species Name")]
        public int SpeciesId { get; set; }

        public ICollection<Species> Species { get; set; }
        public virtual ICollection<Donation> Donation { get; set; }
    }
}
