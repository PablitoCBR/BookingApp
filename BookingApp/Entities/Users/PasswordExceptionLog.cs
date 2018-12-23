using System;

namespace BookingApp.Entities.Users
{
    public class PasswordExceptionLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public string ParamName { get; set; }
    }
}
