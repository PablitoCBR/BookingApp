using System;


namespace BookingApp.Exceptions
{
    public class AuthorizationException : Exception
    {
        public int SourceId { get; set; }
        public AuthorizationException(int id, string message) : base(message)
        {
            SourceId = id;
        }
    }
}
