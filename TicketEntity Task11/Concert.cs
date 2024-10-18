using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketEntity
{
    public class Concert : Event
    {
        public string Band { get; set; }  


        public Concert(string name, string band, int totalSeats, decimal ticketPrice, Venue venue)
        {
            Name = name;
            Band = band;
            TotalSeats = totalSeats;
            TicketPrice = ticketPrice;
            AvailableSeats = totalSeats;
            EventType = "Concert";
        }
    }
}
