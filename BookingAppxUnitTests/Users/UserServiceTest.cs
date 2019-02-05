﻿using Xunit;
using System.Linq;
using BookingApp.Services.Users;
using BookingApp.Contextes.Users;
using BookingApp.Interfaces.Services.Users;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using BookingApp.Entities.Users;
using BookingApp.Repositories;
using AutoMapper;
using BookingApp.Helpers;
using System;


namespace BookingAppxUnitTests.Users
{
    public class UserServiceTest
    {
        private readonly User _user = new User()
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
        private SqliteConnection _connection = new SqliteConnection("DataSource=:memory:");


        [Fact]
        public void RegisterTest()
        {
            _connection.Open();
            try
            {
                var userOptions = new DbContextOptionsBuilder<UserContext>().UseSqlite(_connection).Options;

                using (var userContext = new UserContext(userOptions))
                {
                    userContext.Database.EnsureCreated();
                }

                using (var userContext = new UserContext(userOptions))
                {
                    IUserService userService = new UserService
                            (
                                new UserRepository(userContext),
                                null,
                                new PasswordHandler(),
                                new UserDataValidator(),
                                null
                            );
                    var userexpected = userService.Create(_user, "admin");
                    Assert.NotNull(userexpected);

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
                _connection.Close();
            }

        }

        [Fact]
        public void AuthenticateTest()
        {
            _connection.Open();
            try
            {
                var userOptions = new DbContextOptionsBuilder<UserContext>().UseSqlite(_connection).Options;

                using (var userContext = new UserContext(userOptions))
                {
                    userContext.Database.EnsureCreated();
                }

                using (var userContext = new UserContext(userOptions))
                {

                    IUserService userService = new UserService
                        (
                            new UserRepository(userContext),
                            null,
                            new PasswordHandler(),
                            new UserDataValidator(),
                            null
                        );
                    string password = "admin";
                    var userexpected = userService.Create(_user, password);
                    Assert.NotNull(userexpected);

                    var response = userService.Authenticate("Anna", password);
                    Assert.NotNull(response);

                }

            }
            finally
            {
                _connection.Close();
            }
        }

        [Fact]
        public void GetByIdTest()
        {
            _connection.Open();
            try
            {
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            }
            catch (Exception) { }

            try
            {
                var userOptions = new DbContextOptionsBuilder<UserContext>().UseSqlite(_connection).Options;

                using (var userContext = new UserContext(userOptions))
                {
                    userContext.Database.EnsureCreated();
                }

                using (var userContext = new UserContext(userOptions))
                {

                    IUserService userService = new UserService
                        (
                             new UserRepository(userContext),
                            null,
                            new PasswordHandler(),
                            new UserDataValidator(),
                            Mapper.Instance
                        );
                    string password = "admin";
                    var userexpected = userService.Create(_user, password);
                    Assert.NotNull(userexpected);

                    var response = userService.GetById(1);
                    Assert.NotNull(response);
                }

            }
            finally
            {
                _connection.Close();
            }
        }



        [Fact]
        public void DeleteTest()
        {
            _connection.Open();
            try
            {
                var userOptions = new DbContextOptionsBuilder<UserContext>().UseSqlite(_connection).Options;

                using (var userContext = new UserContext(userOptions))
                {
                    userContext.Database.EnsureCreated();
                }

                using (var userContext = new UserContext(userOptions))
                {
                    IUserService userService = new UserService
                        (
                            new UserRepository(userContext),
                            null,
                            new PasswordHandler(),
                            new UserDataValidator(),
                            null
                        );
                    string password = "admin";
                    var userexpected = userService.Create(_user, password);
                    Assert.NotNull(userexpected);

                    Assert.Equal(1, userContext.Users.Count());
                    userService.Delete(1);
                    Assert.Equal(0, userContext.Users.Count());
                }

            }
            finally
            {
                _connection.Close();
            }
        }

        [Fact]
        public void UpdateTest()
        {
            _connection.Open();
            try
            {
                var userOptions = new DbContextOptionsBuilder<UserContext>().UseSqlite(_connection).Options;

                using (var userContext = new UserContext(userOptions))
                {
                    userContext.Database.EnsureCreated();
                }

                using (var userContext = new UserContext(userOptions))
                {
                    IUserService userService = new UserService
                        (
                            new UserRepository(userContext),
                            null,
                            new PasswordHandler(),
                            new UserDataValidator(),
                            null
                        );
                    var userexpected = userService.Create(_user, "admin");
                    Assert.NotNull(userexpected);
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

                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());

                using (var userContext = new UserContext(userOptions))
                {
                    IUserService userService = new UserService
                        (
                            new UserRepository(userContext),
                            null,
                            new PasswordHandler(),
                            new UserDataValidator(),
                            Mapper.Instance
                        );
                    User updateUser = new User()
                    {
                        Id = 1,
                        BusinessName = "Alfa",
                        Username = "Anna1",
                        Address = new Address()
                        {
                            City = "Gdańsk",
                            PostalCode = "87-300",
                            Street = "Henryka Sienkiewicza",
                            Number = "25"
                        }
                    };
                    userService.Update(updateUser, "admin1");
                }
                using (var userContext = new UserContext(userOptions))
                {
                    Assert.Equal(1, userContext.Users.Count());
                    Assert.Equal("Alfa", userContext.Users.Single().BusinessName);
                    Assert.Equal("Anna1", userContext.Users.Single().Username);
                    Assert.Equal("Gdańsk", userContext.Addresses.Single().City);
                    Assert.NotNull(userContext.Users.Single().PasswordHash);
                    Assert.NotNull(userContext.Users.Single().PasswordSalt);
                }
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
