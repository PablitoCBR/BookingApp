using System;

namespace BookingApp.Exceptions
{
    public class PasswordHandlerException : Exception
    {
        public DateTime Date { get; set; }
        public string ParamName { get; set; }
        public PasswordHandlerException(string paramName, DateTime date, string message) 
            : base(message)
        {
            Date = date;
            ParamName = paramName;
        }        
    }
}
