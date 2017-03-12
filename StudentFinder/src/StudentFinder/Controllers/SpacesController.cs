using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentFinder.Data;
using StudentFinder.Models;

namespace StudentFinder.Controllers
{
    public class SpacesController : Controller
    {
        private readonly StudentFinderContext _context;

        public SpacesController(StudentFinderContext context)
        {
            _context = context;    
        }

        // GET: Spaces
        public async Task<IActionResult> Index(string sortOrder, string currentFilter,
            string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["RoomSortParm"] = String.IsNullOrEmpty(sortOrder) ? "room_desc" : "";
            ViewData["LocationSortParm"] = sortOrder == "location" ? "location_desc" : "Location";
            ViewData["DescriptionSortParm"] = sortOrder == "description" ? "description_desc" : "Description";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var space = from s in _context.Space
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                space = space.Where(s => s.Room.Contains(searchString));
                //|| s.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "room_desc":
                    space = space.OrderByDescending(s => s.Room);
                    break;
                case "location":
                    space = space.OrderBy(s => s.Location);
                    break;

                case "location_desc":
                    space = space.OrderByDescending(s => s.Location);
                    break;
                case "description":
                    space = space.OrderBy(s => s.Description);
                    break;

                case "description_desc":
                    space = space.OrderByDescending(s => s.Description);
                    break;
                default:
                    space = space.OrderBy(s => s.Id);
                    break;

            }
            
                return View(await _context.Space.ToListAsync());
            

        }

        
        // GET: Spaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var space = await _context.Space.SingleOrDefaultAsync(m => m.Id == id);
            if (space == null)
            {
                return NotFound();
            }

            return View(space);
        }

        // GET: Spaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Location,Room")] Space space)
        {
            if (ModelState.IsValid)
            {
                _context.Add(space);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(space);
        }

        // GET: Spaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var space = await _context.Space.SingleOrDefaultAsync(m => m.Id == id);
            if (space == null)
            {
                return NotFound();
            }
            return View(space);
        }

        // POST: Spaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Location,Room")] Space space)
        {
            if (id != space.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(space);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaceExists(space.Id))
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
            return View(space);
        }

        // GET: Spaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var space = await _context.Space.SingleOrDefaultAsync(m => m.Id == id);
            if (space == null)
            {
                return NotFound();
            }

            return View(space);
        }

        // POST: Spaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var space = await _context.Space.SingleOrDefaultAsync(m => m.Id == id);
            _context.Space.Remove(space);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SpaceExists(int id)
        {
            return _context.Space.Any(e => e.Id == id);
        }
    }
}
