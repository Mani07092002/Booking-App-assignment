using BookingEntity;
using System;

namespace BookingDao
{
    public interface IEventServiceProvider
    {
        Event CreateEvent(string eventName, DateTime date, TimeSpan time, int totalSeats, decimal ticketPrice, string eventType, Venue venue);
        Event[] GetEventDetails();
        int GetAvailableNoOfTickets();
    }
}
