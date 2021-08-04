using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadTruck.Models
{
    public enum Model
    {
        FH,
        FM
    }
    public class Truck
    {
        [Key]
        public long id { get; set; }
        public Model model { get; set; }
        public DateTime yearFabrication { get; set; }
        public DateTime yearModel { get; set; }

    }
}
