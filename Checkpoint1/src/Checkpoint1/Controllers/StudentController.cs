using Microsoft.AspNetCore.Mvc;
using Checkpoint1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Checkpoint1.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationContext db_context;

        public StudentController (ApplicationContext context)
        {
            db_context = context;
        }


        public IActionResult Index()
        {
            
            return View(db_context.Student.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {

            db_context.Student.Add(student);
            db_context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }
    }
}
