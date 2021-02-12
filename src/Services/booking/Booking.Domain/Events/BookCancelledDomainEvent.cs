using Booking.Domain.BookingAggregate;
using MediatR;

namespace Booking.Domain.Events
{
    public class BookCancelledDomainEvent : INotification
    {
        public Book Book { get; }

        public BookCancelledDomainEvent(Book book)
        {
            Book = book;
        }
    }
}
