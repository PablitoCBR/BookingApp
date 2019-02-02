using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace BookingApp.Entities.Schedules
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public int Day { get; set; } // 0-6
        public TimeSpan? Opening { get; set; }
        public TimeSpan? Closeing { get; set; }
    }
}
