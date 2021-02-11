using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Model;

namespace Vehicles.API.Infraestructure.EntityConfigurations
{
    class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .UseHiLo("vehicle_hilo")
               .IsRequired();

            builder.Property(ci => ci.LicensePlate)
                .HasMaxLength(10)
                .IsRequired(true);

            builder.Property(ci => ci.HourPrice)
                .IsRequired(true);

            builder.Property(ci => ci.FuelType)
                .IsRequired(true);

            builder.Property(ci => ci.TrunkCapacity)
                .IsRequired(true);

            builder.Property(ci => ci.Year)
                .IsRequired(true);

            builder.HasOne(ci => ci.VehicleBrand)
               .WithMany()
               .HasForeignKey(ci => ci.VehicleBrandId);

            builder.HasOne(ci => ci.VehicleType)
               .WithMany()
               .HasForeignKey(ci => ci.VehicleTypeId);
        }
    }
}
