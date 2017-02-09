using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
   
    }
}
