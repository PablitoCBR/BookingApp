using BookingApp.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Entities.Accounts;
using BookingApp.Dtos.Schedules;
using System;
using BookingApp.Exceptions;

namespace BookingApp.Controllers
{
    [Authorize(Roles = Role.Business)]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ScheduleDto schedule = _scheduleService.Get(id);
                return Ok(schedule);
            }
            catch(ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}")]
        public IActionResult Create(int id, [FromBody]ScheduleDto scheduleDto)
        {
            if (Convert.ToInt32(User.Identity.Name) != id)
                return Unauthorized();

            try
            {
                _scheduleService.Create(id, scheduleDto);
                return Ok();
            }
            catch(ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ScheduleDto scheduleDto)
        {
            if (Convert.ToInt32(User.Identity.Name) != id)
                return Unauthorized();

            try
            {
                _scheduleService.Update(id, scheduleDto);
                return Ok();
            }
            catch(ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            if (Convert.ToInt32(User.Identity.Name) != id)
                return Unauthorized();

            try
            {
                _scheduleService.Remove(id);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}