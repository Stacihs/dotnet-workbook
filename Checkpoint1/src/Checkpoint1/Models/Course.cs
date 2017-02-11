using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint1.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Student> Student { get; set; }
   
    }
}
