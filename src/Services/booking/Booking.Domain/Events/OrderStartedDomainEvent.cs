using Booking.Domain.BookingAggregate;
using MediatR;

namespace Booking.Domain.Events
{
    /// <summary>
    /// Event used when an book is created
    /// </summary>
    public class BookStartedDomainEvent : INotification
    {
        public string CustomerId { get; }
        public string CustomerName { get; }
        public Book Book { get; }

        public BookStartedDomainEvent(Book book, string customerId, string customerName)
        {
            Book = book;
            CustomerId = customerId;
            CustomerName = customerName;
        }
    }
}
