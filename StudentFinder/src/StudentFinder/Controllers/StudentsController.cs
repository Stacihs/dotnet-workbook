using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentFinder.Data;
using StudentFinder.Models;
using StudentFinder.Models.ViewModels;

namespace StudentFinder.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentFinderContext _context;

        public StudentsController(StudentFinderContext context)
        {
            _context = context;    
        }

        // GET: Students
        public async Task<IActionResult> Index(string searchString, int? page)
        {

            //var spaceSort = _context.StudentScheduleSpace.OrderBy(c => c. Space.Id).Select(a => new { id = a.i})

            var spaceList = _context.Space.OrderBy(s => s.Room).Select(a => new { id = a.Id, value = a.Room }).ToList();
            ViewBag.SpaceSelectList = new SelectList(spaceList, "id", "value");

            var scheduleList = _context.Schedule.OrderBy(s => s.Label).Select(a => new { id = a.Id, value = a.Label }).ToList();
            ViewBag.ScheduleSelectList = new SelectList(scheduleList, "id", "value");

            
            IQueryable<StudentsViewModel> studentsVM;

            var student = new Student();
            var some_ID = 1;

            var s_all = _context.StudentScheduleSpace.Where(s => s.ScheduleId == some_ID).Select(x => x);

            var test = s_all.Select(s => new StudentsViewModel()
            {
                StudentId = s.Student.Id,
                fName = s.Student.fName,
                lName = s.Student.lName,
                GradeLevel = s.Student.GradeLevel,
                SpaceId = s.Space.Id,
                Room = s.Space.Room,
                Location = s.Space.Location
            });
                
            
            return View(await _context.Student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            var spaceList = _context.Space.OrderBy(s => s.Room).Select(a => new { id = a.Id, value = a.Room }).ToList();
            ViewBag.SpaceSelectList = new SelectList(spaceList, "id", "value");

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GradeLevel,StudentSchoolId,StudentsSchool,fName,lName")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaceList = _context.Space.OrderBy(s => s.Room).Select(a => new { id = a.Id, value = a.Room }).ToList();
            ViewBag.SpaceSelectList = new SelectList(spaceList, "id", "value");

            var student = await _context.Student.SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GradeLevel,StudentId,StudentsSchool,fName,lName")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.SingleOrDefaultAsync(m => m.Id == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }

        public void CompleteStudentSearch ()
        {
            var students_all = _context.StudentScheduleSpace.Select(s => new StudentsViewModel()
            {
                StudentId = s.Student.Id,
                fName = s.Student.fName,
                lName = s.Student.lName,
                GradeLevel = s.Student.GradeLevel,
                SpaceId = s.Space.Id,
                Room = s.Space.Room,
                Location = s.Space.Location
            });

          
        }
    }
}
