using Microsoft.AspNetCore.Mvc;
using BookingApp.Interfaces.Services.Schedules;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Helpers;
using BookingApp.Dtos.Schedules;
using System.Collections.Generic;
using BookingApp.Entities.Schedules;

namespace BookingApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // guest making reservation
        [AllowAnonymous]
        [HttpPost("{id}")]
        public IActionResult Create(int id, [FromBody]ReservationDto reservation)
        {
            try
            {
                _reservationService.MakeReservation(id, reservation);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // cancel reservation
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _reservationService.CancelReservation(id);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // returns reservations for user with given id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ICollection<Reservation> reservations = _reservationService.GetReservations(id);
                return Ok(reservations);
            }
            catch(AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // confirm reservation
        [HttpPut("{id}")]
        public IActionResult Confirm(int id)
        {
            try
            {
                _reservationService.ConfirmReservation(id);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}