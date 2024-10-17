namespace BookingEntity
{
    public class Venue
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue() { }

        public Venue(string venueName, string address)
        {
            VenueName = venueName;
            Address = address;
        }

        public void DisplayVenueDetails()
        {
            Console.WriteLine($"Venue Name: {VenueName}, Address: {Address}");
        }
    }
}

