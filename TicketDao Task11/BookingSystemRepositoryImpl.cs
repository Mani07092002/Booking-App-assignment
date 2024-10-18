using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TicketDao;
using TicketEntity;
using TicketException;
using Ticketutil;

namespace YourProject.Dao
{
    public class BookingSystemRepositoryImpl : IBookingSystemRepository
    {
        private readonly string connectionString = DBUtil.GetConnectionString();

        public void AddEvent(Event newEvent)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Event (Name, Date, Time, TotalSeats, AvailableSeats, TicketPrice, EventType) VALUES (@Name, @Date, @Time, @TotalSeats, @AvailableSeats, @TicketPrice, @EventType)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", newEvent.Name);
                cmd.Parameters.AddWithValue("@Date", newEvent.Date);
                cmd.Parameters.AddWithValue("@Time", newEvent.Time);
                cmd.Parameters.AddWithValue("@TotalSeats", newEvent.TotalSeats);
                cmd.Parameters.AddWithValue("@AvailableSeats", newEvent.AvailableSeats);
                cmd.Parameters.AddWithValue("@TicketPrice", newEvent.TicketPrice);
                cmd.Parameters.AddWithValue("@EventType", newEvent.EventType);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public Event GetEventByName(string eventName)
        {
            Event eventDetails = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Event WHERE Name = @Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", eventName);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    eventDetails = new Event(
                        reader["Name"].ToString(),
                        DateTime.Parse(reader["Date"].ToString()),
                        TimeSpan.Parse(reader["Time"].ToString()),
                        int.Parse(reader["TotalSeats"].ToString()),
                        decimal.Parse(reader["TicketPrice"].ToString()),
                        reader["EventType"].ToString()
                    );
                }

                conn.Close();
            }

            return eventDetails;
        }

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Event";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Event eventDetails = new Event(
                        reader["Name"].ToString(),
                        DateTime.Parse(reader["Date"].ToString()),
                        TimeSpan.Parse(reader["Time"].ToString()),
                        int.Parse(reader["TotalSeats"].ToString()),
                        decimal.Parse(reader["TicketPrice"].ToString()),
                        reader["EventType"].ToString()
                    );
                    events.Add(eventDetails);
                }

                conn.Close();
            }

            return events;
        }

        public void BookTickets(Booking booking)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Booking (EventName, NumberOfTickets, TotalCost) VALUES (@EventName, @NumberOfTickets, @TotalCost)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EventName", booking.EventName);
                cmd.Parameters.AddWithValue("@NumberOfTickets", booking.NumberOfTickets);
                cmd.Parameters.AddWithValue("@TotalCost", booking.TotalCost);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CancelBooking(int bookingId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Booking WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", bookingId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Booking> GetBookings()
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Booking";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Booking booking = new Booking(
                        reader["EventName"].ToString(),
                        int.Parse(reader["NumberOfTickets"].ToString()),
                        new List<Customer>(), // Placeholder for customers
                        decimal.Parse(reader["TotalCost"].ToString())
                    );
                    bookings.Add(booking);
                }

                conn.Close();
            }

            return bookings;
        }
    }
}
