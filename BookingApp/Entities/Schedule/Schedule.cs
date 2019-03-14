using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Entities.Schedule
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public WorkingHours Monday { get; set; }
        public WorkingHours Tuesday { get; set; }
        public WorkingHours Wednesday { get; set; }
        public WorkingHours Thursday { get; set; }
        public WorkingHours Friday { get; set; }
        public WorkingHours Saturday { get; set; }
        public WorkingHours Sunday { get; set; }
    }
}
