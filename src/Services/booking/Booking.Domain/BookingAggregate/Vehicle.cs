using Booking.Domain.Seedwork;
using System;

namespace Booking.Domain.BookingAggregate
{
    public class Vehicle : Entity
    {
        private string licensePlate;
        private DateTime startTime;
        private DateTime endTime;

        public int VehicleId { get; private set; }

        public Vehicle(int vehicleId, string licensePlate, DateTime startTime, DateTime endTime)
        {
            VehicleId = vehicleId;
            this.licensePlate = licensePlate;
            this.startTime = startTime;
            this.endTime = endTime;
        }

    }
}
