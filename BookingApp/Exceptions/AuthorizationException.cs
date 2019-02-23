using System;


namespace BookingApp.Exceptions
{
    public class AuthorizationException : Exception
    {
        public DateTime Date { get; set; }
        public int SourceId { get; set; }
        public AuthorizationException(int id, DateTime date, string message) : base(message)
        {
            SourceId = id;
            Date = date;
        }
    }
}
