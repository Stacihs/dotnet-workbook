using System.Collections.Generic;

namespace ESpecies.Models
{
    public class Species
    {
        public int SpeciesId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string DonorId { get; set; }
        public decimal Donation { get; set; }

        public ICollection<Donor> Donor { get; set; }
   
    }
}
