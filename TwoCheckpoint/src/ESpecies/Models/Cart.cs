using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace ESpecies.Models
{
    public class Carts
    {
       [Key]
       public int ApplicationUserId { get; set; } 
       public int EntityId { get; set; }
       public string Amount { get; set; }

    }
    
}
