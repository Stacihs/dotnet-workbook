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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {

            }
            return View(db_context.Student.ToList());
        }

        //add student
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {

            db_context.Student.Add(student);
            db_context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        

    }
}
