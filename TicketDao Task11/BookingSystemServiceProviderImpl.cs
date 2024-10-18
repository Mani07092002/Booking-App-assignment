using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketEntity;
using TicketException;

namespace TicketDao
{
    public class BookingSystemServiceProviderImpl : IBookingSystemServiceProvider
    {
        private readonly IBookingSystemRepository repository;

        public BookingSystemServiceProviderImpl(IBookingSystemRepository repository)
        {
            this.repository = repository;
        }

        public void CreateEvent(Event newEvent)
        {
            repository.AddEvent(newEvent);
        }

        public Event GetEventByName(string eventName)
        {
            return repository.GetEventByName(eventName);
        }

        public List<Event> GetAllEvents()
        {
            return repository.GetAllEvents();
        }

        public void BookTickets(string eventName, List<Customer> customers, int numberOfTickets)
        {
            Event eventDetails = repository.GetEventByName(eventName);
            if (eventDetails != null && eventDetails.AvailableSeats >= numberOfTickets)
            {
                Booking booking = new Booking(eventName, numberOfTickets, customers, eventDetails.TicketPrice * numberOfTickets);
                repository.BookTickets(booking);
            }
        }

        public void CancelBooking(int bookingId)
        {
            repository.CancelBooking(bookingId);
        }

        public List<Booking> GetAllBookings()
        {
            return repository.GetBookings();
        }
    }
}
