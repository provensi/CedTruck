using CedTruck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CedTruck.Services.Interfaces
{
    public interface ITrucksService
    {
        List<Truck> GetAll();

        Truck GetById(long? id);

        void DeleteById(long? id);

        List<TruckModel> GetAllTruckModels();
    }
}
