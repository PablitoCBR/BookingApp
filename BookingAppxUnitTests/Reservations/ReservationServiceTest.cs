using Xunit;
using BookingApp.Interfaces.Services.Schedules;
using BookingApp.Services.Schedules;
using BookingApp.Repositories;
using BookingApp.Contextes;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookingApp.Helpers;
using System;
using BookingAppxUnitTests.Schedules;
using BookingApp.Dtos.Schedules;
using BookingApp.Entities.Schedules;
using System.Collections.Generic;
using System.Linq;

namespace BookingAppxUnitTests.Reservations
{
    public class ReservationServiceTest
    {
        private readonly SqliteConnection _connection;
        private readonly DbContextOptions<ScheduleContext> _scheduleOptions;

        public ReservationServiceTest()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _scheduleOptions = new DbContextOptionsBuilder<ScheduleContext>().UseSqlite(_connection).Options;
        }

        [Fact]
        public void AddAndGetReservations()
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
                using (var scheduleContext = new ScheduleContext(_scheduleOptions))
                {
                    scheduleContext.Database.EnsureCreated();
                    IReservationService reservationService = new ReservationService
                        (
                            new ReservationRepository(scheduleContext),
                            new TemplateUserRepository(),
                            new TempScheduleRepository(),
                            Mapper.Instance
                        );
                    ReservationDto reservation = new ReservationDto()
                    {
                        Date = new DateTime(2018, 2, 8, 10, 00, 00),
                        DurationOfServiceMinutes = 30,
                        ServiceType = "Hair cut",
                        Confirmed = false
                    };
                    reservationService.MakeReservation(1, reservation);

                    reservation = new ReservationDto()
                    {
                        Date = new DateTime(2019, 2, 8, 10, 00, 00),
                        DurationOfServiceMinutes = 30,
                        ServiceType = "cut",
                        Confirmed = false
                    };
                    reservationService.MakeReservation(1, reservation);

                    var reservations = reservationService.GetReservations(1);
                    Assert.Equal(2, reservations.Count);
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        [Fact]
        public void Confirm()
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
                using (var scheduleContext = new ScheduleContext(_scheduleOptions))
                {
                    scheduleContext.Database.EnsureCreated();
                    IReservationService reservationService = new ReservationService
                        (
                            new ReservationRepository(scheduleContext),
                            new TemplateUserRepository(),
                            new TempScheduleRepository(),
                            Mapper.Instance
                        );
                    ReservationDto reservation = new ReservationDto()
                    {
                        Date = new DateTime(2018, 2, 8, 10, 00, 00),
                        DurationOfServiceMinutes = 30,
                        ServiceType = "Hair cut",
                        Confirmed = false
                    };
                    reservationService.MakeReservation(1, reservation);

                    reservationService.ConfirmReservation(1);
                    var reservations = reservationService.GetReservations(1);
                    Assert.True(reservations.SingleOrDefault(x => x.Id == 1).Confirmed);
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        [Fact]
        public void Remove()
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
                using (var scheduleContext = new ScheduleContext(_scheduleOptions))
                {
                    scheduleContext.Database.EnsureCreated();
                    IReservationService reservationService = new ReservationService
                        (
                            new ReservationRepository(scheduleContext),
                            new TemplateUserRepository(),
                            new TempScheduleRepository(),
                            Mapper.Instance
                        );
                    ReservationDto reservation = new ReservationDto()
                    {
                        Date = new DateTime(2018, 2, 8, 10, 00, 00),
                        DurationOfServiceMinutes = 30,
                        ServiceType = "Hair cut",
                        Confirmed = false
                    };
                    reservationService.MakeReservation(1, reservation);

                    Assert.Equal(1, reservationService.GetReservations(1).Count);
                    reservationService.CancelReservation(1);
                    Assert.Equal(0, reservationService.GetReservations(1).Count);
                }
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
