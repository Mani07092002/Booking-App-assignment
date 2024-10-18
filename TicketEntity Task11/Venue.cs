namespace TicketEntity
{
    public class Venue
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Address { get; set; } 
        public string City { get; set; }  

        public Venue(string name, string address, string city)
        {
            Name = name;
            Address = address;
            City = city;
        }
    }
}
