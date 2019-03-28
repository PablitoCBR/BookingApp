using Xunit;
using Moq;
using BookingApp.Entities.Accounts;
using BookingApp.Interfaces.Repositories;
using BookingApp.Interfaces.Security;
using BookingApp.Interfaces.Services;
using BookingApp.Services.Accounts;
using BookingApp.Dtos.Accounts;
using AutoMapper;
using BookingApp.Exceptions;
using BookingApp.Helpers;

namespace BookingAppxTests.Accounts
{
    public class BusinessServiceTest
    {
        private Business business = new Business
        {
            Email = "company@company.com",
            CompanyName = "Company",
            PhoneNumber = "123456789",
            Address = null
        };
        private readonly Address address = new Address
        {
            City = "Gdańsk",
            PostalCode = "80-120",
            Street = "Aleja Grunwaldzka",
            Number = "260",
            Flat = "40"
        };
        private readonly string password = "password";

        [Fact]
        public void Authenticate()
        {
            var repositoryMock = new Mock<IBusinessRepository>();
            var accountManagerMock = new Mock<IAccountManager<Business>>();
            accountManagerMock.Setup(x => x.Authenticate(business.Email, password, repositoryMock.Object)).Returns(new Business());

            IBusinessService businessService = new BusinessService(repositoryMock.Object, null, accountManagerMock.Object, null);

            Business result = businessService.Authenticate(business.Email, password);
            Assert.NotNull(result);
        }

        [Fact]
        public void Register()
        {
            AddressValidator addressValidator = new AddressValidator();
            var repositoryMock = new Mock<IBusinessRepository>();
            var accountManagerMock = new Mock<IAccountManager<Business>>();
            accountManagerMock.Setup(x => x.CreateUser(business, password, repositoryMock.Object));
            repositoryMock.Setup(x => x.CheckIfExist(business.Email, business.CompanyName)).Returns(false);

            IBusinessService businessService = new BusinessService(repositoryMock.Object, null, accountManagerMock.Object, addressValidator);

            Assert.Throws<ValidationException>(() => businessService.Create(business, password));

            business.Address = address;

            businessService.Create(business, password);

            accountManagerMock.Verify(x => x.CreateUser(business, password, repositoryMock.Object), Times.Once);
        }

        [Fact]
        public void Delete()
        {
            var repositoryMock = new Mock<IBusinessRepository>();

            IBusinessService businessService = new BusinessService(repositoryMock.Object, null, null, null);

            Assert.Throws<ValidationException>(() => businessService.Delete(1));

            repositoryMock.Setup(x => x.Get(1)).Returns(business);
            repositoryMock.Setup(x => x.Remove(business));

            businessService.Delete(1);
            repositoryMock.Verify(x => x.Remove(business), Times.Once);
        }

        [Fact]
        public void Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            var repositoryMock = new Mock<IBusinessRepository>();

            IBusinessService businessService = new BusinessService(repositoryMock.Object, mapper, null, null);

            Assert.Throws<ValidationException>(() => businessService.Get(1));

            repositoryMock.Setup(x => x.Get(1)).Returns(new Business());
            BusinessDto result = businessService.Get(1);
            Assert.NotNull(result);

        }
        [Fact]
        public void Update()
        {
            AddressValidator addressValidator = new AddressValidator();
            var repositoryMock = new Mock<IBusinessRepository>();
            var accountManagerMock = new Mock<IAccountManager<Business>>();
            repositoryMock.Setup(x => x.CheckIfExist(business.Email, password)).Returns(false);
            repositoryMock.Setup(x => x.Get(1)).Returns(business);
            accountManagerMock.Setup(x => x.Update(business, repositoryMock.Object, password));

            business.Id = 1;

            IBusinessService businessService = new BusinessService(repositoryMock.Object, null, accountManagerMock.Object, addressValidator);

            Assert.Throws<ValidationException>(() => businessService.Update(business, password));

            business.Address = address;
            businessService.Update(business, password);

            accountManagerMock.Verify(x => x.Update(business, repositoryMock.Object, password), Times.Once);
        }
    }
}
