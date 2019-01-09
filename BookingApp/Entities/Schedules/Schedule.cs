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
        [ForeignKey("User")]
        public int UserId { get; set; }
        public WorkingHours Monday { get; set; }
        public WorkingHours Tuesday { get; set; }
        public WorkingHours Wednesday { get; set; }
        public WorkingHours Thursday { get; set; }
        public WorkingHours Friday { get; set; }
        public WorkingHours Saturday { get; set; }
        public WorkingHours Sunday { get; set; }

    }
    [ComplexType]
    public class WorkingHours
    {
        [Required]
        public TimeSpan Opening { get; set; }
        [Required]
        public TimeSpan Closeing { get; set; }
    }
}
