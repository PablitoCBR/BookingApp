namespace BookingApp.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Username { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
