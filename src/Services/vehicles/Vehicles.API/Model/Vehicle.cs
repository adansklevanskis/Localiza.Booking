namespace Vehicles.API.Model
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string LicensePlate { get; set; }

        public int Year { get; set; }

        public decimal HourPrice { get; set; }

        public FuelType FuelType { get; set; }


        public int VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }

        public int VehicleBrandId { get; set; }

        public VehicleBrand VehicleBrand { get; set; }


        public int TrunkCapacity { get; set; }

        public Category Category { get; set; }


    }
}