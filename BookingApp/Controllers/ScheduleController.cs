using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BookingApp.Services.Schedules;
using BookingApp.Interfaces.Schedules;

namespace BookingApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

    }
}