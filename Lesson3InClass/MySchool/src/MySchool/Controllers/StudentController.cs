using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySchool.Models;
using NuGet.Packaging;

namespace MySchool.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Levels intro = new Levels() { Id = 1, Name = "intro" };
            Levels intermediate = new Levels() { Id = 2, Name= "intermediate" };
            Levels advanced = new Levels() { Id = 3, Name = "advanced" };

            Student Fred = new Student() { Id = 1, Name = "Fred" , Levels = intro };
            Student John = new Student() { Id = 2, Name = "John", Levels = intermediate };
            Student Betty = new Student() { Id = 3, Name = "Betty", Levels = advanced};

            List<Student> studentList = new List<Student>();
            studentList.Add(Fred);
            studentList.Add(John);
            studentList.Add(Betty);
            

            return View(studentList);
        } 
           
    }
}
