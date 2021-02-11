using Microsoft.EntityFrameworkCore;
using Vehicles.API.Infraestructure.EntityConfigurations;
using Vehicles.API.Model;

namespace Vehicles.API.Infraestructure
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new VehicleBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new VehicleTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
        }
    }
}
