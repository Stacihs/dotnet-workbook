using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentFinder.Data;
using StudentFinder.Models;

namespace StudentFinder.Controllers
{
    public class StudentScheduleSpacesController : Controller
    {
        private readonly StudentFinderContext _context;

        public StudentScheduleSpacesController(StudentFinderContext context)
        {
            _context = context;    
        }

        // GET: StudentScheduleSpaces
        public async Task<IActionResult> Index()
        {
            var studentFinderContext = _context.StudentScheduleSpace.Include(s => s.Schedule).Include(s => s.Space).Include(s => s.Student);
            return View(await studentFinderContext.ToListAsync());
        }

        // GET: StudentScheduleSpaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentScheduleSpace = await _context.StudentScheduleSpace.SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentScheduleSpace == null)
            {
                return NotFound();
            }

            return View(studentScheduleSpace);
        }

        // GET: StudentScheduleSpaces/Create
        public IActionResult Create()
        {
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "From");
            ViewData["SpaceId"] = new SelectList(_context.Space, "Id", "Description");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "GradeLevel");
            return View();
        }

        // POST: StudentScheduleSpaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,ScheduleId,SpaceId")] StudentScheduleSpace studentScheduleSpace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentScheduleSpace);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "From", studentScheduleSpace.ScheduleId);
            ViewData["SpaceId"] = new SelectList(_context.Space, "Id", "Description", studentScheduleSpace.SpaceId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "GradeLevel", studentScheduleSpace.StudentId);
            return View(studentScheduleSpace);
        }

        // GET: StudentScheduleSpaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentScheduleSpace = await _context.StudentScheduleSpace.SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentScheduleSpace == null)
            {
                return NotFound();
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "From", studentScheduleSpace.ScheduleId);
            ViewData["SpaceId"] = new SelectList(_context.Space, "Id", "Description", studentScheduleSpace.SpaceId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "GradeLevel", studentScheduleSpace.StudentId);
            return View(studentScheduleSpace);
        }

        // POST: StudentScheduleSpaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,ScheduleId,SpaceId")] StudentScheduleSpace studentScheduleSpace)
        {
            if (id != studentScheduleSpace.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentScheduleSpace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentScheduleSpaceExists(studentScheduleSpace.StudentId))
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
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "From", studentScheduleSpace.ScheduleId);
            ViewData["SpaceId"] = new SelectList(_context.Space, "Id", "Description", studentScheduleSpace.SpaceId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "GradeLevel", studentScheduleSpace.StudentId);
            return View(studentScheduleSpace);
        }

        // GET: StudentScheduleSpaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentScheduleSpace = await _context.StudentScheduleSpace.SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentScheduleSpace == null)
            {
                return NotFound();
            }

            return View(studentScheduleSpace);
        }

        // POST: StudentScheduleSpaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentScheduleSpace = await _context.StudentScheduleSpace.SingleOrDefaultAsync(m => m.StudentId == id);
            _context.StudentScheduleSpace.Remove(studentScheduleSpace);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentScheduleSpaceExists(int id)
        {
            return _context.StudentScheduleSpace.Any(e => e.StudentId == id);
        }
    }
}
