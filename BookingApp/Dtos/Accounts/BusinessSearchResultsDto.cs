namespace BookingApp.Dtos.Accounts
{
    public class BusinessSearchResultsDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto Address { get; set; }
    }
}
