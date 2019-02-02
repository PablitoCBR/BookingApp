using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Interfaces.Schedules;
using BookingApp.Dtos.Schedules;
using BookingApp.Helpers;
using System.Collections.Generic;
using System;

namespace BookingApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromHeader]int id, [FromBody]List<ScheduleDto> schedules)
        {
            try
            {
                _scheduleService.AddSchedule(id, schedules);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ICollection<ScheduleDto> weekSchedule = _scheduleService.GetWeekSchedule(id);
                return Ok(weekSchedule);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }       
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _scheduleService.RemoveSchedule(id);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

       [HttpPut("{id}")]
       public IActionResult  Update(int id, [FromBody]List<ScheduleDto> schedulesToUpdate)
       {
            try
            {
                _scheduleService.UpdateSchedule(id, schedulesToUpdate);
                return Ok();
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
       }

    }
}