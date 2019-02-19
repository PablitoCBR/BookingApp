using System;

namespace BookingApp.Exceptions
{
    public class PasswordHandlerException : Exception
    {
        public DateTime Time { get; set; }
        public string ParamName { get; set; }
        public PasswordHandlerException(string paramName, DateTime time, string message) 
            : base(message)
        {
            Time = time;
            ParamName = paramName;
        }        
    }
}
