using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketEntity;

namespace TicketDao
{
    public interface IBookingSystemRepository
    {
        void AddEvent(Event newEvent); 
        Event GetEventByName(string eventName); 
        List<Event> GetAllEvents(); 
        void BookTickets(Booking booking); 
        void CancelBooking(int bookingId);
        List<Booking> GetBookings(); 
    }
}
