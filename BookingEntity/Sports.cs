using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEntity
{
    public class Sport : Event
    {
        public Sport(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sport") { }

        public void DisplaySportDetails()
        {
            Console.WriteLine($"Sport Event: {EventName} on {EventDate.ToShortDateString()} at {EventTime} in {Venue.VenueName}");
        }
    }
}
