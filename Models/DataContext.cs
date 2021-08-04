using CedTruck.Models;
using Microsoft.EntityFrameworkCore;

namespace CedTruck
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Truck> Trucks { get; set; }
        
        public DbSet<TruckModel> TruckModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TruckModel>().HasData(
                new TruckModel { Id = 1, Model = "FH" },
                new TruckModel { Id = 2, Model = "FM" }
            );

        }
    }
}