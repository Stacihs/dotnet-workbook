using Checkpoint1.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint1.Models
{
    public class Course
    {
        [Required]
        [Display(Name = "Course ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Course Title")]
        public string Title { get; set; }
        
        
        public virtual ICollection<Student> Student { get; set; }
   
    }
}
