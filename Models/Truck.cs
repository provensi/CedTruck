using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CedTruck.Models
{
    public class Truck
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Truck Model")]
        public TruckModel Model { get; set; }
        [Display(Name ="Fabrication Year")]
        public DateTime YearFabrication { get; set; }
        [Display(Name = "Model Year")]
        public DateTime YearModel { get; set; }

    }
}
