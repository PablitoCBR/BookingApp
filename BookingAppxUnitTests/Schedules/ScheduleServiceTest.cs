using BookingApp.Dtos.Schedules;
using Xunit;
using BookingApp.Contextes;
using BookingApp.Interfaces.Services.Schedules;
using BookingApp.Services.Schedules;
using BookingApp.Repositories;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using AutoMapper;
using BookingApp.Helpers;
using System.Linq;


namespace BookingAppxUnitTests.Schedules
{
    public class ScheduleServiceTest
    {
        private readonly IList<ScheduleDto> weekSchedule = new List<ScheduleDto>();
        private readonly SqliteConnection _connection;
        private readonly DbContextOptions<ScheduleContext> _scheduleOptions;
        public ScheduleServiceTest()
        {
            weekSchedule.Add(new ScheduleDto() { Day = 0, Opening = null, Closeing = null });
            weekSchedule.Add(new ScheduleDto() { Day = 1, Opening = new TimeSpan(8, 0, 0), Closeing = new TimeSpan(18, 0, 0) });
            weekSchedule.Add(new ScheduleDto() { Day = 2, Opening = new TimeSpan(8, 0, 0), Closeing = new TimeSpan(18, 0, 0) });
            weekSchedule.Add(new ScheduleDto() { Day = 3, Opening = new TimeSpan(8, 0, 0), Closeing = new TimeSpan(18, 0, 0) });
            weekSchedule.Add(new ScheduleDto() { Day = 4, Opening = new TimeSpan(8, 0, 0), Closeing = new TimeSpan(18, 0, 0) });
            weekSchedule.Add(new ScheduleDto() { Day = 5, Opening = new TimeSpan(10, 0, 0), Closeing = new TimeSpan(14, 0, 0) });
            weekSchedule.Add(new ScheduleDto() { Day = 6, Opening = null, Closeing = null });
            _connection = new SqliteConnection("DataSource=:memory:");
            _scheduleOptions = new DbContextOptionsBuilder<ScheduleContext>().UseSqlite(_connection).Options;
        }

        [Fact]
        public void AddAndGetScheduleTest()
        {
            _connection.Open();
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            try
            {
                using (var scheduleContext = new ScheduleContext(_scheduleOptions))
                {
                    scheduleContext.Database.EnsureCreated();
                    IScheduleService scheduleService = new ScheduleService
                         (
                              new ScheduleRepository(scheduleContext),
                              new TemplateUserRepository(),
                              Mapper.Instance
                          );

                    scheduleService.AddSchedule(1, weekSchedule);
                    Assert.Equal(7, scheduleService.GetWeekSchedule(1).Count);
                }
            }
            finally
            {
                _connection.Close();
            }
        }
        [Fact]
       
        public void RemoveScheduleTest()
        {
            _connection.Open();
            try
            {
                using (var scheduleContext = new ScheduleContext(_scheduleOptions))
                {
                    scheduleContext.Database.EnsureCreated();
                    IScheduleService scheduleService = new ScheduleService
                         (
                              new ScheduleRepository(scheduleContext),
                              new TemplateUserRepository(),
                              null
                          );

                    scheduleService.AddSchedule(1, weekSchedule);
                    scheduleService.RemoveSchedule(1);
                    Assert.Throws<AppException>(() => scheduleService.GetWeekSchedule(1).Count);
                   
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        [Fact]
        public void UpdateScheduleTest()
        {
            _connection.Open();
            try
            {
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            } catch(Exception) { }
 
            try
            {
                using (var scheduleContext = new ScheduleContext(_scheduleOptions))
                {
                    scheduleContext.Database.EnsureCreated();
                    IScheduleService scheduleService = new ScheduleService
                         (
                              new ScheduleRepository(scheduleContext),
                              new TemplateUserRepository(),
                              Mapper.Instance
                          );

                    scheduleService.AddSchedule(1, weekSchedule);
                    List<ScheduleDto> toUpdate = new List<ScheduleDto>
                    {
                        new ScheduleDto() { Day = 1, Opening = null, Closeing = null }
                    };
                    IList<ScheduleDto> data = scheduleService.GetWeekSchedule(1);
                    Assert.NotNull(data.SingleOrDefault(x => x.Day == 1).Opening);
                    scheduleService.UpdateSchedule(1, toUpdate);
                    data = scheduleService.GetWeekSchedule(1);
                    Assert.Null(data.SingleOrDefault(x => x.Day == 1).Opening);
                }
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
