using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketEntity;

namespace TicketDao
{
    public interface IBookingSystemServiceProvider
    {
        void CreateEvent(Event newEvent);
        Event GetEventByName(string eventName);
        List<Event> GetAllEvents();
        void BookTickets(string eventName, List<Customer> customers, int numberOfTickets); 
        void CancelBooking(int bookingId); 
        List<Booking> GetAllBookings();
    }
}
