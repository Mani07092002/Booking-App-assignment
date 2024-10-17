using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEntity
{
    public class Concert : Event
    {
        public Concert(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Concert") { }

        public void DisplayConcertDetails()
        {
            Console.WriteLine($"Concert Event: {EventName} on {EventDate.ToShortDateString()} at {EventTime} in {Venue.VenueName}");
        }
    }
}
