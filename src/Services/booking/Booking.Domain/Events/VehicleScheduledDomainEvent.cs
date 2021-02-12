using Booking.Domain.BookingAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.Events
{
    /// <summary>
    /// Event used when an vehicle is scheduled
    /// </summary>
    public class VehicleScheduledDomainEvent : INotification
    {
        public VehicleScheduledDomainEvent(Book book)
        {
            Book = book;
        }

        public Book Book { get; }
    }
}
