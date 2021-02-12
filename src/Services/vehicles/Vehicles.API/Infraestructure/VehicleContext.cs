using Microsoft.EntityFrameworkCore;
using Vehicles.API.Infraestructure.EntityConfigurations;
using Vehicles.API.Model;

namespace Vehicles.API.Infraestructure
{
    /// <summary>
    /// Class Vehicle Context
    /// </summary>
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleBrandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
        }
    }
}
