using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using BookingApp.Entities.Users;

namespace BookingApp.Entities.Schedules
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int DurationOfServiceMinutes { get; set; }
        [Required]
        [MinLength(3)]
        public string ServiceType { get; set; }
        public string OptionalDescription { get; set; }
        [Required]
        public bool Confirmed { get; set; }
    }
}
