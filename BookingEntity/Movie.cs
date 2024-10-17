using BookingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEntity
{
    public class Movie : Event
    {
        public Movie(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Movie") { }

        public void DisplayMovieDetails()
        {
            Console.WriteLine($"Movie Event: {EventName} on {EventDate.ToShortDateString()} at {EventTime} in {Venue.VenueName}");
        }
    }
}
