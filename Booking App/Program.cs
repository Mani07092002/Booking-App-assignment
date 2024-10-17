using System;
using BookingEntity;
using BookingDao;
using Bookingexception;
using BookingUtil;

class Program
{
        private static IEventServiceProvider eventService = new EventServiceProviderImpl();
        private static IBookingSystemServiceProvider bookingService = new BookingSystemServiceProviderImpl(eventService);

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the Ticket Booking System!");
                while (true)
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Create Event");
                    Console.WriteLine("2. Book Tickets");
                    Console.WriteLine("3. Cancel Booking");
                    Console.WriteLine("4. Get Booking Details");
                    Console.WriteLine("5. Get Event Details");
                    Console.WriteLine("6. Exit");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            CreateEvent();
                            break;
                        case "2":
                            BookTickets();
                            break;
                        case "3":
                            CancelBooking();
                            break;
                        case "4":
                            GetBookingDetails();
                            break;
                        case "5":
                            GetEventDetails();
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }
            catch (NullPointerException ex)
            {
                Console.WriteLine($"Null Pointer Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void CreateEvent()
        {
            try
            {
                Console.Write("Enter Event Name: ");
                string eventName = Console.ReadLine();

                Console.Write("Enter Event Date (yyyy-mm-dd): ");
                DateTime eventDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Event Time (hh:mm): ");
                TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());

                Console.Write("Enter Total Number of Seats: ");
                int totalSeats = int.Parse(Console.ReadLine());

                Console.Write("Enter Ticket Price: ");
                decimal ticketPrice = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Event Type (Movie/Sport/Concert): ");
                string eventType = Console.ReadLine();

                Console.Write("Enter Venue Name: ");
                string venueName = Console.ReadLine();

                Console.Write("Enter Venue Address: ");
                string venueAddress = Console.ReadLine();

                Venue venue = new Venue(venueName, venueAddress);
                eventService.CreateEvent(eventName, eventDate, eventTime, totalSeats, ticketPrice, eventType, venue);
                Console.WriteLine("Event created successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the event: {ex.Message}");
            }
        }

        private static void BookTickets()
        {
            try
            {
                Console.Write("Enter Event Name: ");
                string eventName = Console.ReadLine();

                Event eventObj = Array.Find(eventService.GetEventDetails(), e => e.EventName == eventName);
                if (eventObj == null)
                {
                    throw new EventNotFoundException("Event not found.");
                }

                Console.Write("Enter Number of Tickets: ");
                int numTickets = int.Parse(Console.ReadLine());

                Customer[] customers = new Customer[numTickets];
                for (int i = 0; i < numTickets; i++)
                {
                    Console.Write($"Enter Customer Name for Ticket {i + 1}: ");
                    string customerName = Console.ReadLine();
                    Console.Write($"Enter Customer Email for Ticket {i + 1}: ");
                    string email = Console.ReadLine();
                    Console.Write($"Enter Customer Phone Number for Ticket {i + 1}: ");
                    string phoneNumber = Console.ReadLine();
                    customers[i] = new Customer(customerName, email, phoneNumber);
                }

                Booking booking = bookingService.BookTickets(eventObj, customers, numTickets);
                Console.WriteLine("Tickets booked successfully!");
                booking.DisplayBookingDetails();
            }
            catch (EventNotFoundException ex)
            {
                Console.WriteLine($"Event Not Found Exception: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while booking tickets: {ex.Message}");
            }
        }

        private static void CancelBooking()
        {
            try
            {
                Console.Write("Enter Booking ID to cancel: ");
                int bookingId = int.Parse(Console.ReadLine());
                bookingService.CancelBooking(bookingId);
                Console.WriteLine("Booking cancelled successfully!");
            }
            catch (InvalidBookingIDException ex)
            {
                Console.WriteLine($"Invalid Booking ID Exception: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Booking ID format. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while cancelling booking: {ex.Message}");
            }
        }

        private static void GetBookingDetails()
        {
            try
            {
                Console.Write("Enter Booking ID: ");
                int bookingId = int.Parse(Console.ReadLine());
                Booking booking = bookingService.GetBookingDetails(bookingId);
                Console.WriteLine("Booking Details:");
                booking.DisplayBookingDetails();
            }
            catch (InvalidBookingIDException ex)
            {
                Console.WriteLine($"Invalid Booking ID Exception: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Booking ID format. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving booking details: {ex.Message}");
            }
        }

        private static void GetEventDetails()
        {
            var events = eventService.GetEventDetails();
            Console.WriteLine("Available Events:");
            foreach (var eventObj in events)
            {
                eventObj.DisplayEventDetails();
            }
        }
    }
