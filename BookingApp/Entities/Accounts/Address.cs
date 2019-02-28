using System.ComponentModel.DataAnnotations;

namespace BookingApp.Entities.Accounts
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MinLength(6),MaxLength(6)]
        public string PostalCode { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        [MaxLength(10)]
        public string Number { get; set; }
        public string Flat { get; set; }
    }
}
