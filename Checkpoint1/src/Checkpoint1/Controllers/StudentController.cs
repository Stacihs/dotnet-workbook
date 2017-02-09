using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Checkpoint1.Models;
using System.Linq;


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
            Course intro = new Course() { Id = 1, Name = "Introduction" };
            Course intermediate = new Course() { Id = 2, Name = "Intermediate" };
            Course advanced = new Course() { Id = 3, Name = "Advanced" };

            Student Fred = new Student() { Id = 1, FirstName = "Fred", LastName = "Smith", Courses = intro };
            Student John = new Student() { Id = 2, FirstName = "John", LastName = "Doe", Courses = intermediate };
            Student Bob = new Student() { Id = 3, FirstName = "Bob", LastName = "Jackson", Courses = advanced };
            Student Sam = new Student() { Id = 4, FirstName = "Sam", LastName = "Jones", Courses = advanced };
            Student Jill = new Student() { Id = 5, FirstName = "Jill", LastName = "Downing", Courses = intermediate };
            



            List<Student> studentsList = new List<Student>();





            return base.View(studentsList);
        }


    }
            
}
