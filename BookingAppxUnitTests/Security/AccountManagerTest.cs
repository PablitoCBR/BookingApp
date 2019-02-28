using BookingApp.Security;
using Xunit;
using BookingApp.Interfaces.Repositories;
using Moq;
using BookingApp.Entities.Accounts;
using Microsoft.Extensions.Logging;
using BookingApp.Exceptions;

namespace BookingAppxUnitTests.Security
{
    public class AccountManagerTest
    {
        private readonly PasswordHandler passwordHandler = new PasswordHandler();
        private readonly Account account = new Account() { Email = "admin@admin.com" };
        private readonly string password = "admin";

        [Fact]
        public void Create()
        {
            var repositoryMock = new Mock<IRepository<Account>>();
            AccountManager<Account> accountManager = new AccountManager<Account>(passwordHandler, new LoggerFactory());

            accountManager.CreateUser(account, password, repositoryMock.Object);
            repositoryMock.Verify(x => x.Add(account), Times.Once);

            Assert.Throws<ValidationException>(() => accountManager.CreateUser(account, null, repositoryMock.Object));
        }

        [Fact]
        public void  Authenticate()
        {
            byte[] passwordHash, passwordSalt;
            passwordHandler.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var repositoryMock = new Mock<IRepository<Account>>();
            repositoryMock.Setup(x => x.Get(account.Email)).Returns(new Account() { PasswordHash = passwordHash, PasswordSalt = passwordSalt});
            AccountManager<Account> accountManager = new AccountManager<Account>(passwordHandler, new LoggerFactory());        

            Account result = accountManager.Authenticate(account.Email, password, repositoryMock.Object);
            Assert.NotNull(result);         
        }

        [Fact]
        public void Update()
        {
            var repositoryMock = new Mock<IRepository<Account>>();
            AccountManager<Account> accountManager = new AccountManager<Account>(passwordHandler, new LoggerFactory());

            accountManager.Update(account, repositoryMock.Object, password);
            repositoryMock.Verify(x => x.Update(account), Times.Once);
        }
    }
}
