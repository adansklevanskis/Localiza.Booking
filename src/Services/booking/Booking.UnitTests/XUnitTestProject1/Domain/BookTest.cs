using Booking.Domain.BookingAggregate;
using Booking.Domain.Events;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Booking.UnitTests.Domain
{
    public class BookTest
    {
        [Fact]
        public void Book_Create_Sucess()
        {
            //Arrange    
            var customerId = "fakeCustomerId";
            var customerName = "FakeCustomerName";

            //Act 
            var fakeBook = new Book(customerId, customerName);

            //Assert
            fakeBook.Should().NotBeNull();
            fakeBook.DomainEvents.Should().ContainItemsAssignableTo<BookStartedDomainEvent>();
        }

        [Fact]
        public void Vehicle_Scheduled_Sucess()
        {
            //Arrange    
            var customerId = "fakeCustomerId";
            var customerName = "FakeCustomerName";
            var vehicleId = 1;
            var licensePlate = "FAKE-123";
            var startTime = DateTime.Now;
            var endTime = DateTime.Now.AddHours(1);

            //Act 
            var fakeBook = new Book(customerId, customerName);
            fakeBook.ScheduleVehicle(vehicleId, licensePlate, startTime, endTime);

            //Assert
            fakeBook.Should().NotBeNull();
            fakeBook.DomainEvents.OfType<VehicleScheduledDomainEvent>().Should().NotBeEmpty();
        }


        [Fact]
        public void Book_Canceled_Sucess()
        {
            //Arrange    
            var customerId = "fakeCustomerId";
            var customerName = "FakeCustomerName";

            //Act 
            var fakeBook = new Book(customerId, customerName);
            fakeBook.SetCancelledStatus();

            //Assert

            fakeBook.DomainEvents.OfType<BookCancelledDomainEvent>().Should().NotBeEmpty();
        }


    }
}
