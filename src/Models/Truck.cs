using System.ComponentModel.DataAnnotations;

namespace CedTruck.Models
{
    public class Truck
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Truck Model Id")]
        public long ModelId { get; set; }
        
        [Display(Name = "Truck Model")]
        public TruckModel Model { get; set; }
        
        [Display(Name ="Fabrication Year")]
        public int YearFabrication { get; set; }
        
        [Display(Name = "Model Year")]
        public int YearModel { get; set; }



    }
}
