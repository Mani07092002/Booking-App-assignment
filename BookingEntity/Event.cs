using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEntity
{
    public abstract class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public Venue Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }

        protected Event(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            TicketPrice = ticketPrice;
            EventType = eventType;
        }

        public decimal CalculateTotalRevenue(int ticketsSold)
        {
            return ticketsSold * TicketPrice;
        }

        public int GetBookedNoOfTickets()
        {
            return TotalSeats - AvailableSeats;
        }

        public void BookTickets(int numTickets)
        {
            if (numTickets > AvailableSeats)
                throw new InvalidOperationException("Not enough available seats.");

            AvailableSeats -= numTickets;
        }

        public void CancelBooking(int numTickets)
        {
            AvailableSeats += numTickets;
        }

        public void DisplayEventDetails()
        {
            Console.WriteLine($"Event Name: {EventName}, Date: {EventDate.ToShortDateString()}, Time: {EventTime}, Available Seats: {AvailableSeats}");
        }
    }
}