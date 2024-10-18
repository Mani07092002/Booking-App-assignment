using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketEntity;
using Ticketutil;

namespace TicketDao
{
    public class EventServiceProviderImpl : IEventServiceProvider
    {
        private readonly IBookingSystemRepository repository;

        public EventServiceProviderImpl(IBookingSystemRepository repository)
        {
            this.repository = repository;
        }

        public void AddEvent(Event eventDetails)
        {
            repository.AddEvent(eventDetails);
        }

        public Event GetEventDetails(string eventName)
        {
            return repository.GetEventByName(eventName);
        }

        public List<Event> GetAllEvents()
        {
            return repository.GetAllEvents();
        }
    }
}
