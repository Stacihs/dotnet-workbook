using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESpecies.Data;
using ESpecies.Models;

namespace ESpecies.Controllers
{
    public class CartsController : Controller
    {
        private readonly SpDbContext dbcontext;

        public CartsController(SpDbContext context)
        {
            dbcontext = context;    
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            return View(await dbcontext.Carts.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await dbcontext.Carts.SingleOrDefaultAsync(m => m.ApplicationUserId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationUserId,EntityId")] Carts cart)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Add(cart);
                await dbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await dbcontext.Carts.SingleOrDefaultAsync(m => m.ApplicationUserId == id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationUserId,EntityId")] Carts cart)
        {
            if (id != cart.ApplicationUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbcontext.Update(cart);
                    await dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.ApplicationUserId))
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
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await dbcontext.Carts.SingleOrDefaultAsync(m => m.ApplicationUserId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await dbcontext.Carts.SingleOrDefaultAsync(m => m.ApplicationUserId == id);
            dbcontext.Carts.Remove(cart);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CartExists(int id)
        {
            return dbcontext.Carts.Any(e => e.ApplicationUserId == id);
        }
    }
}
