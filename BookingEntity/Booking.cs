using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEntity
{
    public class Booking
    {
        public static int BookingIdCounter = 0;
        public int BookingId { get; }
        public Customer[] Customers { get; }
        public Event Event { get; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; }

        public Booking(Event eventObj, Customer[] customers, int numTickets, decimal totalCost)
        {
            BookingId = ++BookingIdCounter;
            Event = eventObj;
            Customers = customers;
            NumTickets = numTickets;
            TotalCost = totalCost;
            BookingDate = DateTime.Now;
        }

        public void DisplayBookingDetails()
        {
            Console.WriteLine($"Booking ID: {BookingId}, Event: {Event.EventName}, Total Tickets: {NumTickets}, Total Cost: {TotalCost:C}, Booking Date: {BookingDate}");
            foreach (var customer in Customers)
            {
                customer.DisplayCustomerDetails();
            }
        }
    }
}
 
