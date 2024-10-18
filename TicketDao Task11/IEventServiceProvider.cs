using TicketEntity;

namespace TicketDao
{
    public interface IEventServiceProvider
    {
        void AddEvent(Event eventDetails);
        Event GetEventDetails(string eventName); 
        List<Event> GetAllEvents();
    }
}
