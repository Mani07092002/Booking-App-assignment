namespace Bookingexception
{
    public class InvalidBookingIDException : Exception
    {
        public InvalidBookingIDException(string message) : base(message) { }
    }
}
