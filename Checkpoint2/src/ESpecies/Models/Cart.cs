using System.ComponentModel.DataAnnotations;


namespace ESpecies.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int SponsorID { get; set; }
        [Display (Name = "Donation Amount")] 
        public decimal Amount { get; set; } 
        [Display (Name = "Name of Species")]
        public string EntityId { get; set; }


        //public virtual Sponsor Sponsor { get; set; }
        //public virtual ICollection<Species> Species { get; set; } 
          

    }
}
