using System;
using System.Collections.Generic;
using System.Linq;

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

        public IList<Schedule> Schedules { get; set; }

        /// <summary>
        /// Add new schedule
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public Schedule AddSchedule(DateTime startTime, DateTime endTime)
        {
            if (startTime < DateTime.Now)
                return null;

            var available = Schedules.Any(s => s.StartTime > endTime || s.EndTime < startTime);

            if (!available)
                return null;

            var schedule = new Schedule()
            {
                StartTime = startTime,
                EndTime = endTime
            };

            Schedules.Add(schedule);
            return schedule;
        }
    }
}