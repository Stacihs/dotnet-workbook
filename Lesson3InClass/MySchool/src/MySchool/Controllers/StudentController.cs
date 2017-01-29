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
            Student Fred = new Student() { Id = 1, Name = "Fred" };
            Student John = new Student() { Id = 2, Name = "John" };
            Student Betty = new Student() { Id = 3, Name = "Betty" };
            List<Student> studentList = new List<Student>();
            studentList.Add(Fred);
            studentList.Add(John);
            studentList.Add(Betty);
            Level levels = new Level() { Id = 1, Label = "Intro" };

            return View(studentList);
        } 
           
    }
}
