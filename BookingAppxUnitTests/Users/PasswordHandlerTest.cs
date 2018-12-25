using Xunit;
using BookingApp.Interfaces.Users;
using BookingApp.Services.Users;
using System;

namespace BookingAppxUnitTests.Users
{
    public class PasswordHandlerTest
    {
        private IPasswordHandler _passwordHandler = new PasswordHandler();
        private string _password = "Kn_KoLoRUG";

        [Fact]
        public void CreatePasswordHashTest()
        {
            byte[] passwordSalt, passwordHash;
            _passwordHandler.CreatePasswordHash(_password, out passwordHash, out passwordSalt);
            Assert.NotNull(passwordHash);
            Assert.NotNull(passwordHash);
            Assert.Equal(64, passwordHash.Length);
            Assert.Equal(128, passwordSalt.Length);
        }

        [Fact]
        public void VarifyPasswordHashTest()
        {
            string wrongPassword = "knkolorug";
            byte[] passwordSalt, passwordHash;
            _passwordHandler.CreatePasswordHash(_password, out passwordHash, out passwordSalt);

            Assert.True(_passwordHandler.VerifyPasswordHash(_password, passwordHash, passwordSalt));
            Assert.False(_passwordHandler.VerifyPasswordHash(wrongPassword, passwordHash, passwordSalt));
            Assert.Throws<ArgumentException>(() => _passwordHandler.VerifyPasswordHash(null, passwordHash, passwordSalt));
        }
    }
}
