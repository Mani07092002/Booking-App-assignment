using BookingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDao
{
    public class EventServiceProviderImpl : IEventServiceProvider
    {
        private readonly List<Event> _events = new List<Event>();

        public Event CreateEvent(string eventName, DateTime date, TimeSpan time, int totalSeats, decimal ticketPrice, string eventType, Venue venue)
        {
            Event newEvent;

            switch (eventType)
            {
                case "Movie":
                    newEvent = new Movie(eventName, date, time, venue, totalSeats, ticketPrice);
                    break;
                case "Sport":
                    newEvent = new Sport(eventName, date, time, venue, totalSeats, ticketPrice);
                    break;
                case "Concert":
                    newEvent = new Concert(eventName, date, time, venue, totalSeats, ticketPrice);
                    break;
                default:
                    throw new InvalidOperationException("Invalid event type.");
            }

            _events.Add(newEvent);
            return newEvent;
        }

        public Event[] GetEventDetails()
        {
            return _events.ToArray();
        }

        public int GetAvailableNoOfTickets()
        {
            int totalAvailable = 0;
            foreach (var eventObj in _events)
            {
                totalAvailable += eventObj.AvailableSeats;
            }
            return totalAvailable;
        }
    }

}
