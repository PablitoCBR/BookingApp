using System;


namespace BookingApp.Exceptions
{
    public class ValidationException : Exception
    {
        public object[] Arguments { get; set; }
        public ValidationException(string message, params object[] arguments) : base(message)
        {
            Arguments = arguments;
        }
    }
}
