using System.ComponentModel.DataAnnotations;

namespace Checkpoint1.Models
{

    public class Student

    {
        [Required]
        [Display(Name = "Student ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }
        

        public virtual Course Course { get; set; }

    }
}        