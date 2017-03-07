using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESpecies.Models
{
    public class Donation
    {
        [Key]
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public string Amount { get; set; }
        public string EntityID { get; set; }

      //  public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
       // public virtual ICollection<Species> Species { get; set; }
    }
}
