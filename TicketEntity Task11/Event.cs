using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketEntity
{
    public class Event
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public DateTime Date { get; set; } 
        public TimeSpan Time { get; set; } 
        public int TotalSeats { get; set; } 
        public int AvailableSeats { get; set; }  
        public decimal TicketPrice { get; set; } 
        public string EventType { get; set; } 

        public Event(string name, DateTime date, TimeSpan time, int totalSeats, decimal ticketPrice, string eventType)
        {
            Name = name;
            Date = date;
            Time = time;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            TicketPrice = ticketPrice;
            EventType = eventType;
        }
    }
}
