using CedTruck.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CedTruck.Controllers
{
    public class TrucksController : Controller
    {
        private readonly DataContext _context;

        public TrucksController(DataContext context)
        {
            _context = context;
        }

        // GET: Trucks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trucks.ToListAsync());
        }

        // GET: Trucks/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // GET: Trucks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,model,yearFabrication,yearModel")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(truck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

        // GET: Trucks/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks.FindAsync(id);
            if (truck == null)
            {
                return NotFound();
            }
            return View(truck);
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,model,yearFabrication,yearModel")] Truck truck)
        {
            if (id != truck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(truck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckExists(truck.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

        // GET: Trucks/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var truck = await _context.Trucks.FindAsync(id);
            _context.Trucks.Remove(truck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(long id)
        {
            return _context.Trucks.Any(e => e.Id == id);
        }
    }
}
