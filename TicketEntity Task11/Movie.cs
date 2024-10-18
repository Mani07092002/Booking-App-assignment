using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketEntity
{
    public class Movie : Event
    {
        public string Director { get; set; } 


        public Movie(string name, string director, int totalSeats, decimal ticketPrice, Venue venue)
        {
            Name = name;
            Director = director;
            TotalSeats = totalSeats;
            TicketPrice = ticketPrice;
            AvailableSeats = totalSeats;
            EventType = "Movie";
        }
    }
}
