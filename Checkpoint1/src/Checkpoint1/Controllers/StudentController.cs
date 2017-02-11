using Microsoft.AspNetCore.Mvc;
using Checkpoint1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Checkpoint1.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationContext db_context;

        public StudentController(ApplicationContext context)
        {
            db_context = context;
        }

        public ActionResult Create()
        {
            return View();
        }
        public IActionResult Index()
        {
            //test Student objects
           // var Student = new Student() { Id = 1, FirstName = "Jenny", LastName = "Smith", CourseId = 1 };

            var students = db_context.Student.Include(c => c.Course);



            return View(students.ToList());
        }


    }
            
}
