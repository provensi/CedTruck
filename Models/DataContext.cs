using CadTruck.Models;
using Microsoft.EntityFrameworkCore;

namespace CedTruck
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Truck> Trucks { get; set; }
    }
}