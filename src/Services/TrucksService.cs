using CedTruck.Models;
using CedTruck.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CedTruck.Services
{
    public class TrucksService : ITrucksService
    {
        private readonly DataContext _context;

        public TrucksService(DataContext context)
        {
            _context = context;
        }

        public List<Truck> GetAll()
        {
            return _context.Trucks.ToList();
        }

        public Truck GetById(long? id)
        {
            if (!id.HasValue)
            {
                return null;
            }
            return _context.Trucks.FirstOrDefaultAsync(m => m.Id == id).Result;
        }

        public void DeleteById(long? id)
        {
            if (!id.HasValue)
            {
                return;
            }
            var truck = _context.Trucks.FirstOrDefaultAsync(m => m.Id == id).Result;

            _context.Trucks.Remove(truck);
            _context.SaveChangesAsync();            
        }

        public List<TruckModel> GetAllTruckModels()
        {
            return _context.TruckModels.ToList();
        }
    }
}
