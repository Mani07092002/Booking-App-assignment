using BookingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookingexception;

namespace BookingDao
{
    public class BookingSystemServiceProviderImpl : IBookingSystemServiceProvider
    {
        private readonly List<Booking> _bookings = new List<Booking>();
        private readonly IEventServiceProvider _eventServiceProvider;

        public BookingSystemServiceProviderImpl(IEventServiceProvider eventServiceProvider)
        {
            _eventServiceProvider = eventServiceProvider;
        }

        public decimal CalculateBookingCost(int numTickets, decimal ticketPrice)
        {
            return numTickets * ticketPrice;
        }

        public Booking BookTickets(Event eventObj, Customer[] customers, int numTickets)
        {
            if (eventObj == null)
                throw new ArgumentNullException(nameof(eventObj));

            if (customers == null || customers.Length != numTickets)
                throw new ArgumentException("Number of customers must match number of tickets.");

            eventObj.BookTickets(numTickets);
            decimal totalCost = CalculateBookingCost(numTickets, eventObj.TicketPrice);
            Booking booking = new Booking(eventObj, customers, numTickets, totalCost);
            _bookings.Add(booking);
            return booking;
        }

        public void CancelBooking(int bookingId)
        {
            var booking = GetBookingDetails(bookingId);
            if (booking == null)
                throw new InvalidBookingIDException("Invalid booking ID.");

            booking.Event.CancelBooking(booking.NumTickets);
            _bookings.Remove(booking);
        }

        public Booking GetBookingDetails(int bookingId)
        {
            foreach (var booking in _bookings)
            {
                if (booking.BookingId == bookingId)
                {
                    return booking;
                }
            }
            throw new InvalidBookingIDException("Booking ID not found.");
        }
    }
}
