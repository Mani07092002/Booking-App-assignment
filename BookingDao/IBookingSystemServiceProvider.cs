using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEntity;

namespace BookingDao
{
   
        public interface IBookingSystemServiceProvider
        {
            decimal CalculateBookingCost(int numTickets, decimal ticketPrice);
            Booking BookTickets(Event eventObj, Customer[] customers, int numTickets);
            void CancelBooking(int bookingId);
            Booking GetBookingDetails(int bookingId);
        }
    }
