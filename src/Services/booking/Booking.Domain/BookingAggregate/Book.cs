using Booking.Domain.Events;
using Booking.Domain.Seedwork;
using System;

namespace Booking.Domain.BookingAggregate
{
    public class Book : Entity, IAggregateRoot
    {
        private Vehicle vehicle;
        private int bookStatusId;
        private string customerId;
        private string customerName;
        private string description;
        public BookStatus BookStatus { get; private set; }

        public Book(string customerId, string customerName)
        {
            this.customerId = customerId;
            this.customerName = customerName;
            bookStatusId = BookStatus.Submitted.Id;

            description = $"Booking vehicle was submitted.";
            AddDomainEvent(new BookStartedDomainEvent(this, customerId, customerName));
        }

        public void ScheduleVehicle(int vehicleId, string licensePlate, DateTime startTime, DateTime endTime)
        {
            vehicle = new Vehicle(vehicleId, licensePlate, startTime, endTime);
            description = $"Booking vehicle was scheduled.";
            bookStatusId = BookStatus.ScheduleConfirmed.Id;
            AddDomainEvent(new VehicleScheduledDomainEvent(this));
        }

        public void SetCancelledStatus()
        {
            bookStatusId = BookStatus.Cancelled.Id;
            description = $"Booking vehicle was cancelled.";
            AddDomainEvent(new BookCancelledDomainEvent(this));
        }


    }
}
