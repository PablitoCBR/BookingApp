using System.ComponentModel.DataAnnotations;

namespace BookingApp.Entities.Accounts
{
    public class User : Account
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
