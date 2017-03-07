using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESpecies.Data;
using ESpecies.Models;
using System;

namespace ESpecies.Controllers
{
    public class SpeciesController : Controller
    {
        private readonly SpDbContext dbcontext;
             
        public SpeciesController(SpDbContext context)
        {
            dbcontext = context;    
        }

        // GET: Species
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, 
            string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var species = from s in dbcontext.Species
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                species = species.Where(s => s.ComName.Contains(searchString) 
                || s.SciName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    species = species.OrderByDescending(s => s.ComName);
                    break;
                case "Date":
                    species = species.OrderBy(s => s.ListingDate);
                    break;

                case "date_desc":
                    species = species.OrderByDescending(s => s.ListingDate);
                    break;
                default:
                    species = species.OrderBy(s => s.Id);
                    break;

            }
            int pageSize = 20;
            return View(await PaginatedList<Species>.CreateAsync(species.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await dbcontext.Species.SingleOrDefaultAsync(m => m.Id == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // GET: Species/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ComName,CountryId,Description,EntityId,ListingDate,PopAbbrev,PopDesc,SciName,SpCode,StatusId,TSN,VipCode")] Species species)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Add(species);
                await dbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(species);
        }

        // GET: Species/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await dbcontext.Species.SingleOrDefaultAsync(m => m.Id == id);
            if (species == null)
            {
                return NotFound();
            }
            return View(species);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ComName,CountryId,Description,EntityId,ListingDate,PopAbbrev,PopDesc,SciName,SpCode,StatusId,TSN,VipCode")] Species species)
        {
            if (id != species.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbcontext.Update(species);
                    await dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeciesExists(species.Id))
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
            return View(species);
        }

        // GET: Species/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await dbcontext.Species.SingleOrDefaultAsync(m => m.Id == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var species = await dbcontext.Species.SingleOrDefaultAsync(m => m.Id == id);
            dbcontext.Species.Remove(species);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SpeciesExists(int id)
        {
            return dbcontext.Species.Any(e => e.Id == id);
        }
    }
}
