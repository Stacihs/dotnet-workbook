using Microsoft.AspNetCore.Mvc;
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

        
        public IActionResult Index()
        {
            //var course = db_context.Course.Include(s => s.Student);

            return View(db_context.Course.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {

            db_context.Course.Add(course);
            db_context.SaveChanges();

            return RedirectToAction("Index", "Course");
        }
    }
}
