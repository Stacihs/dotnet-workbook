using Checkpoint1.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint1.Models
{
    public class Course
    {
        [Key]
        [Display(Name = "Course ID")]
        public int Id { get; set; }
        [Display(Name = "Course Title")]
        public string Title { get; set; }
        
        [Display(Name = "Student Name")]
        public virtual ICollection<Student> Student { get; set; }
   
    }
}
