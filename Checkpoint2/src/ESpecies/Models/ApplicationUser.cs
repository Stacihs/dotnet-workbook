using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ESpecies.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //public int UserID{ get; set; }
        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }
        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }
        //[Display(Name = "Donation Amount")]
        //public decimal DonationAmount { get; set; }

        //public ICollection<Species> Species { get; set; }
        //public virtual ICollection<Donation> Donation { get; set; }
    }
}
