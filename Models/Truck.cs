using System;
using System.ComponentModel.DataAnnotations;

namespace CedTruck.Models
{
    public class Truck
    {
        [Key]
        public long Id { get; set; }
        public TruckModel Model { get; set; }
        public DateTime YearFabrication { get; set; }
        public DateTime YearModel { get; set; }

    }
}
