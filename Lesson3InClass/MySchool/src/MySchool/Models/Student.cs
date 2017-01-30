using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LevelsId { get; set; }

        public virtual Levels Levels { get; set; }
    }
}
