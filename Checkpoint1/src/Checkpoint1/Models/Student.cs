﻿using Microsoft.EntityFrameworkCore;

namespace Checkpoint1.Models
{
   
    public class Student

    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseId { get; set; }
        

        public virtual Course Course { get; set; }
    }
}
    