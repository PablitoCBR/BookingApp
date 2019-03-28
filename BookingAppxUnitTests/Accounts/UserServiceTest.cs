using Xunit;
using BookingApp.Entities.Accounts;
using BookingApp.Interfaces.Services;
using BookingApp.Services.Accounts;
using Moq;
using BookingApp.Helpers;
using AutoMapper;
using BookingApp.Interfaces.Security;
using BookingApp.Interfaces.Repositories;
using BookingApp.Dtos.Accounts;
using BookingApp.Exceptions;

namespace BookingAppxTests.Accounts
{
    public class UserServiceTest
    {
        private readonly User user = new User()
        {
            Id = 1,
            Email = "admin@admin.com",
            Name = "Admin",
            Surname = "Admin"
        };
        private readonly string password = "admin";

        [Fact]
        public void Register()
        {
            var accountManagerMock = new Mock<IAccountManager<User>>();
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(x => x.CheckIfExist(user.Email)).Returns(false);

            // User service instance
            IUserService userService = new UserService(repositoryMock.Object, null, accountManagerMock.Object);

            userService.Create(user, password);
            accountManagerMock.Verify(x => x.CreateUser(user, password, repositoryMock.Object), Times.Once);
        }

        [Fact]
        public void Authenticate()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var accountManagerMock = new Mock<IAccountManager<User>>();
            accountManagerMock.Setup(x => x.Authenticate(user.Email, password, repositoryMock.Object)).Returns(new User());

            // User service instance
            IUserService userService = new UserService(repositoryMock.Object, null, accountManagerMock.Object);

            User result = userService.Authenticate(user.Email, password);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(x => x.Get(1)).Returns(new User());

            // User service instance
            IUserService userService = new UserService(repositoryMock.Object, mapper, null);

            UserDto result = userService.Get(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void Update()
        {
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(x => x.Get(1)).Returns(new User() { Id = 1, Email = "e@gmail.com"});
            repositoryMock.Setup(x => x.CheckIfExist(user.Email)).Returns(true);
            var accountManagerMock = new Mock<IAccountManager<User>>();
            accountManagerMock.Setup(x => x.Update(user, repositoryMock.Object, null));
           
            IUserService userService = new UserService(repositoryMock.Object, null, accountManagerMock.Object);

            // Case: email already exist (Validation Exception expected)       
            Assert.Throws<ValidationException>(() => userService.Update(user, null));
            accountManagerMock.Verify(x => x.Update(user, repositoryMock.Object, null), Times.Never);

            // Case: can update data
            repositoryMock.Setup(x => x.Get(1)).Returns(user);
            userService.Update(user, null);
            accountManagerMock.Verify(x => x.Update(user, repositoryMock.Object, null), Times.Once);
        }

        [Fact]
        public void Delete()
        {
            var repositoryMock = new Mock<IUserRepository>();

            IUserService userService = new UserService(repositoryMock.Object, null, null);

            // Case: user not found
            Assert.Throws<ValidationException>(() => userService.Delete(1));

            // Case: user found
            repositoryMock.Setup(x => x.Get(1)).Returns(user);
            userService.Delete(1);
            repositoryMock.Verify(x => x.Remove(user), Times.Once);
        }
    }
}
