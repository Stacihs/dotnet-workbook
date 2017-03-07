using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ESpecies.Models
{
    //Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
