using Booking.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.BookingAggregate
{
    public class BookStatus : Enumeration
    {
        public static readonly BookStatus Submitted = new BookStatus(1, nameof(Submitted).ToLowerInvariant());
        public static readonly BookStatus ScheduleConfirmed = new BookStatus(3, nameof(ScheduleConfirmed).ToLowerInvariant());
        public static readonly BookStatus Cancelled = new BookStatus(6, nameof(Cancelled).ToLowerInvariant());

        public BookStatus(int id, string name)
            : base(id, name)
        {
        }

    }
}
