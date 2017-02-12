using Microsoft.AspNetCore.Mvc;
using Checkpoint1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

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
            var course = db_context.Course.Include(s => s.Student);

            return View(db_context.Course.ToList());
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public ActionResult Create()
        {
            return View();
        }

        //add and save course to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {

            db_context.Course.Add(course);
            db_context.SaveChanges();

            return RedirectToAction("Index", "Course");
        }

        public ActionResult Edit(int? Id)
        {
            
            var course = db_context.Course.SingleOrDefault(c => c.Id == Id);

            if (Id == null)
            
                return HttpNotFound();
            

            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {

                db_context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            var course = db_context.Course.SingleOrDefault(c => c.Id == Id);

            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            Course course = db_context.Course.SingleOrDefault(c => c.Id == Id);
            db_context.Course.Remove(course);
            db_context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db_context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
    

