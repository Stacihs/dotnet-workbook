using System.ComponentModel.DataAnnotations;

namespace Checkpoint1.Models
{

    public class Student

    {
        [Key]
        [Display(Name = "Student ID")]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }
        
        [Display(Name = "Course")]
        public virtual Course Course { get; set; }
    }
}
    