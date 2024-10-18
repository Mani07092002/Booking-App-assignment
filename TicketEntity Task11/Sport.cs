using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketEntity
{
    public class Sport : Event
    {
        public string Team { get; set; } 


        public Sport(string name, string team, int totalSeats, decimal ticketPrice, Venue venue)
        {
            Name = name;
            Team = team;
            TotalSeats = totalSeats;
            TicketPrice = ticketPrice;
            AvailableSeats = totalSeats;
            EventType = "Sport";
        }
    }

}
