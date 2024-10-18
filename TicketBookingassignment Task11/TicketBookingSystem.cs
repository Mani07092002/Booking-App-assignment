using TicketEntity;
using TicketDao;
using TicketException;
using Ticketutil;
using System;
using YourProject.Dao;
class TicketBookingSystem
{
        static void Main(string[] args)
        {
            IBookingSystemRepository bookingRepository = new BookingSystemRepositoryImpl();
            IBookingSystemServiceProvider bookingService = new BookingSystemServiceProviderImpl(bookingRepository);
            IEventServiceProvider eventService = new EventServiceProviderImpl(bookingRepository);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the Ticket Booking System!");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. Get Available Seats for Event");
                Console.WriteLine("5. Get Event Details");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Create Event
                        Console.WriteLine("Create a New Event:");
                        Console.Write("Enter Event Name: ");
                        string eventName = Console.ReadLine();
                        Console.Write("Enter Event Date (YYYY-MM-DD): ");
                        DateTime eventDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter Event Time (HH:MM): ");
                        TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());
                        Console.Write("Enter Total Seats: ");
                        int totalSeats = int.Parse(Console.ReadLine());
                        Console.Write("Enter Ticket Price: ");
                        decimal ticketPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Event Type (Concert, Movie, Sport): ");
                        string eventType = Console.ReadLine();

                        Event newEvent = new Event(eventName, eventDate, eventTime, totalSeats, ticketPrice, eventType);
                        bookingService.CreateEvent(newEvent);
                        Console.WriteLine("Event Created Successfully!");
                        break;

                    case "2": // Book Tickets
                        Console.WriteLine("Book Tickets for an Event:");
                        Console.Write("Enter Event Name: ");
                        string bookEventName = Console.ReadLine();
                        Console.Write("Enter Number of Tickets: ");
                        int numberOfTickets = int.Parse(Console.ReadLine());

                        List<Customer> customers = new List<Customer>();
                        for (int i = 0; i < numberOfTickets; i++)
                        {
                            Console.WriteLine($"Enter details for Customer {i + 1}:");
                            Console.Write("Enter Customer Name: ");
                            string customerName = Console.ReadLine();
                            Console.Write("Enter Customer Email: ");
                            string customerEmail = Console.ReadLine();
                            Console.Write("Enter Customer Phone Number: ");
                            string customerPhone = Console.ReadLine();
                            Console.Write("Enter Customer Address: ");
                            string customerAddress = Console.ReadLine();
                            Console.Write("Enter Customer Credit Score (1-100): ");
                            int creditScore = int.Parse(Console.ReadLine());

                            Customer customer = new Customer(customerName, customerEmail, customerPhone, customerAddress, creditScore);
                            customers.Add(customer);
                        }

                        bookingService.BookTickets(bookEventName, customers, numberOfTickets);
                        Console.WriteLine("Tickets Booked Successfully!");
                        break;

                    case "3": // Cancel Booking
                        Console.WriteLine("Cancel a Booking:");
                        Console.Write("Enter Booking ID: ");
                        int bookingId = int.Parse(Console.ReadLine());
                        bookingService.CancelBooking(bookingId);
                        Console.WriteLine("Booking Cancelled Successfully!");
                        break;

                    case "4": // Get Available Seats for Event
                        Console.Write("Enter Event Name to Check Available Seats: ");
                        string seatsEventName = Console.ReadLine();
                        Event seatsEvent = bookingService.GetEventByName(seatsEventName);
                        if (seatsEvent != null)
                        {
                            Console.WriteLine($"Event: {seatsEvent.Name}, Available Seats: {seatsEvent.AvailableSeats}");
                        }
                        else
                        {
                            Console.WriteLine("Event Not Found!");
                        }
                        break;

                    case "5": // Get Event Details
                        Console.Write("Enter Event Name to Get Details: ");
                        string detailsEventName = Console.ReadLine();
                        Event detailsEvent = bookingService.GetEventByName(detailsEventName);
                        if (detailsEvent != null)
                        {
                            Console.WriteLine("Event Details:");
                            Console.WriteLine($"Name: {detailsEvent.Name}");
                            Console.WriteLine($"Date: {detailsEvent.Date}");
                            Console.WriteLine($"Time: {detailsEvent.Time}");
                            Console.WriteLine($"Total Seats: {detailsEvent.TotalSeats}");
                            Console.WriteLine($"Available Seats: {detailsEvent.AvailableSeats}");
                            Console.WriteLine($"Ticket Price: {detailsEvent.TicketPrice}");
                            Console.WriteLine($"Event Type: {detailsEvent.EventType}");
                        }
                        else
                        {
                            Console.WriteLine("Event Not Found!");
                        }
                        break;

                    case "6": // Exit
                        exit = true;
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice! Please enter a number between 1 and 6.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }