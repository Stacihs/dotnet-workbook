using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESpecies.Models
{
    public class Sponsor
    {
        public int DonorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Donation { get; set; }
        public int SpeciesId { get; set; }

        public ICollection<Species> Species { get; set; }
    }
}
