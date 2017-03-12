using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFinder.Models
{
    public class Central
    {
        
        public int StudentId { get; set; }
        public int SpaceId { get; set; }
        public int ScheduleId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Space Space { get; set; }
        public virtual Schedule Schedule { get; set; }

    }
}
