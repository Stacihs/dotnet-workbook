using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Checkpoint1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint1.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationContext db_context;

        public CourseController(ApplicationContext context)
        {
            db_context = context;
        }

        public ActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            var course = db_context.Course.Include(s => s.Student);

            return View(course.ToList());
        }

    }
}
