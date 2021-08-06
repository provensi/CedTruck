using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CedTruck;
using CedTruck.Models;
using CedTruck.Services;
using CedTruck.Services.Interfaces;

namespace CedTruck.Controllers
{
    public class TrucksController : Controller
    {
        private readonly DataContext _context;
        private readonly ITrucksService _trucksService;

        public TrucksController(DataContext context, ITrucksService trucksService)
        {
            _context = context;
            _trucksService = trucksService;
        }

        // GET: Trucks
        public IActionResult Index()
        {
            var trucksList = _trucksService.GetAll(); //_context.Trucks.Include(t => t.Model);
            return View(trucksList);
        }

        // GET: Trucks/Details/5
        public IActionResult Details(long? id)
        {
            var truck = _trucksService.GetById(id);

            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // GET: Trucks/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_trucksService.GetAllTruckModels(), "Id", "Model");
            return View();
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelId,YearFabrication,YearModel")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(truck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_trucksService.GetAllTruckModels(), "Id", "Model", truck.ModelId);
            return View(truck);
        }

        // GET: Trucks/Edit/5
        public IActionResult Edit(long? id)
        {
            var truck = _trucksService.GetById(id);

            if (truck == null)
            {
                return NotFound();
            }

            ViewData["ModelId"] = new SelectList(_context.TruckModels, "Id", "Model", truck.ModelId);
            return View(truck);
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ModelId,YearFabrication,YearModel")] Truck truck)
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
                    if (null == _trucksService.GetById(truck.Id))
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
            ViewData["ModelId"] = new SelectList(_trucksService.GetAllTruckModels(), "Id", "Model", truck.ModelId);
            return View(truck);
        }

        // GET: Trucks/Delete/5
        public IActionResult Delete(long? id)
        {
            var truck = _trucksService.GetById(id);

            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            _trucksService.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
