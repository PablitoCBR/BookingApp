using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookingApp.Entities.Schedules;

namespace BookingApp.Entities.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BusinessName { get; set; }
        [Required]
        [MinLength(2)]
        public string Username { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
    }
}
