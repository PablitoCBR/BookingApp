using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BookingApp.Services.Schedule;
using BookingApp.Interfaces.Schedule;

namespace BookingApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IScheduleService _scheduleService;
        
        public ScheduleController(IScheduleService scheduleService, IMapper mapper)
        {
            _mapper = mapper;
            _scheduleService = scheduleService;
        }
    }
}