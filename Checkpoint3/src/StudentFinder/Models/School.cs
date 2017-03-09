using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFinder.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
        public int Phone { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public TimeZoneInfo Zone {get; set; }
    }
}
