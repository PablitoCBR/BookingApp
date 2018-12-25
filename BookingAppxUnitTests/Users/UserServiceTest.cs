using Xunit;
using System.Linq;
using BookingApp.Services.Users;
using BookingApp.Contextes.Users;
using BookingApp.Interfaces.Users;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using BookingApp.Entities.Users;

namespace BookingAppxUnitTests.Users
{
    public class UserServiceTest
    {
        [Fact]
        public void RegisterTest()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var userOptions = new DbContextOptionsBuilder<UserContext>().UseSqlite(connection).Options;
                var logOptions = new DbContextOptionsBuilder<ErrorLogContext>().UseSqlite(connection).Options;

                using (var userContext = new UserContext(userOptions))
                {
                    userContext.Database.EnsureCreated();
                }

                using (var userContext = new UserContext(userOptions))
                {
                    using (var logContext = new ErrorLogContext(logOptions))
                    {
                        IUserService userService = new UserService
                            (
                                userContext,
                                logContext,
                                new PasswordHandler(),
                                new UserDataValidator()
                            );

                        User user = new User()
                        {
                            BusinessName = "Alfa Brodnica",
                            Username = "Anna",
                            Address = new Address()
                            {
                                City = "Brodnica",
                                PostalCode = "87-300",
                                Street = "Henryka Sienkiewicza",
                                Number = "25"
                            }
                        };
                        string password = "admin";
                        var userexpected = userService.Create(user, password);
                        Assert.NotNull(userexpected);
                    }
                }

                using (var userContext = new UserContext(userOptions))
                {
                    Assert.Equal(1, userContext.Users.Count());
                    Assert.Equal("Alfa Brodnica", userContext.Users.Single().BusinessName);
                    Assert.Equal("Anna", userContext.Users.Single().Username);
                    Assert.Equal("87-300", userContext.Addresses.Single().PostalCode);
                    Assert.NotNull(userContext.Users.Single().PasswordHash);
                    Assert.NotNull(userContext.Users.Single().PasswordSalt);
                }
            }
            finally
            {
                connection.Close();
            }
            
        }

    }
}
