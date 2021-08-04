using CadTruck.Models;
using Microsoft.EntityFrameworkCore;

namespace CedTruck
{
    internal class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Truck> trucks { get; set; }
    }
}