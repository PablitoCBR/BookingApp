using System;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Entities.Users
{
    public class PasswordExceptionLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string ParamName { get; set; }
    }
}
