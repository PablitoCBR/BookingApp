using Xunit;
using BookingApp.Services.Users;
using BookingApp.Interfaces.Users;
using BookingApp.Entities.Users;

namespace BookingAppxUnitTests.Users 
{
    public class UserDataValidatorTest
    {
        private IUserDataValidator _userDataValidator = new UserDataValidator();
        private Address _address = new Address()
        {
            City = "Brodnica",
            PostalCode = "87-300",
            Street = "Matejki",
            Number = "5",
            Flat = null
        };

        [Fact]
        public void ValidateAddressTest()
        {
            Assert.True(_userDataValidator.ValidateAddress(_address));
        }

        [Fact]
        public void ValidatePostalCodeTest()
        {
            string properPostalCode = "87-300";
            string wrongPostalCode = "8-70";

            Assert.True(_userDataValidator.ValidatePostalCode(properPostalCode));
            Assert.False(_userDataValidator.ValidatePostalCode(wrongPostalCode));
        }
        [Fact]
        public void ValidateUserTest()
        {
            User properUser = new User()
            {
                Username = "Paweł",
                BusinessName = "KOLOR",
                Address = _address
            };
            User userWithoutUsername = new User()
            {
                Username = null,
                BusinessName = "KOLOR",
                Address = _address
            };
            User userWithoutAddress = new User()
            {
                Username = "Paweł",
                BusinessName = "KOLOR",
                Address = null
            };
            User userWithWrongAddress = new User()
            {
                Username = "Paweł",
                BusinessName = "KOLOR",
                Address = new Address()
                {
                    City = null,
                    PostalCode = "87-300",
                    Street = "Matejki",
                    Number = "5",
                    Flat = null
                }
            };
            Assert.True(_userDataValidator.ValidateUser(properUser));
            Assert.False(_userDataValidator.ValidateUser(userWithoutUsername));
            Assert.False(_userDataValidator.ValidateUser(userWithoutAddress));
            Assert.False(_userDataValidator.ValidateUser(userWithWrongAddress));
        }
    }
}
