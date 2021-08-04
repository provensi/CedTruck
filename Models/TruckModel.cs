using System;
using System.ComponentModel.DataAnnotations;

namespace CedTruck.Models
{
    public class TruckModel
    {
        [Key]
        public long Id { get; set; }
        public String Model { get; set; }
    }
}
