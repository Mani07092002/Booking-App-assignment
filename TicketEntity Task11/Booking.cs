using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketEntity
{
    public class Booking
    {
        public int Id { get; set; }
        public string EventName { get; set; } 
        public int NumberOfTickets { get; set; } 
        public List<Customer> Customers { get; set; } 
        public decimal TotalCost { get; set; }  

        public Booking(string eventName, int numberOfTickets, List<Customer> customers, decimal totalCost)
        {
            EventName = eventName;
            NumberOfTickets = numberOfTickets;
            Customers = customers;
            TotalCost = totalCost;
        }
    }
}
