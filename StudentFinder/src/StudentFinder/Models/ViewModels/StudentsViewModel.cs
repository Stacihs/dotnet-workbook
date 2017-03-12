﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFinder.Models.ViewModels
{
    public class StudentsViewModel
    {

        //Student Info
        public int StudentId { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string GradeLevel { get; set; }

        //Space Info
        public int SpaceId { get; set; }
        public string Room { get; set; }
        public string Location { get; set; }
                
    }

   
}
