using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BookingApp.Entities.Reservations
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        [Required]
        public DateTime Date { get; set; } 
        [Required]
        public int Duration { get; set; }
        [Required]
        public bool Confirmed { get; set; }
    }
}
