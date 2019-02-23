using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Entities.Accounts
{
    public class Business : Account
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        public virtual Address Address {get; set;}
        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }
    }
}
