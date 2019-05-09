using BookingApp.Dtos.Reservations;
using BookingApp.Entities.Accounts;
using BookingApp.Entities.Reservations;
using BookingApp.Exceptions;
using BookingApp.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this._reservationService = reservationService;
        }

        [Authorize(Roles = Role.User)]
        [HttpPost("make")]
        public IActionResult MakeReservation([FromBody]ReservationDto reservation)
        {
            try
            {
                _reservationService.AddReservation(reservation, Convert.ToInt32(User.Identity.Name));
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = Role.User + "," + Role.Business)]
        [HttpDelete("cancel/{id}")]
        public IActionResult CancelReservation(int id)
        {
            Reservation reservation = _reservationService.GetReservation(id);
            if (reservation == null)
                return BadRequest(new { message = "Reservation not found " });
            int userId = Convert.ToInt32(User.Identity.Name);

            if (User.IsInRole(Role.User))
            {
                if (reservation.UserId != userId)
                    return Unauthorized();
            }
            else
            {
                if (reservation.BusinessId == userId)
                    return Unauthorized();
            }

            _reservationService.CancelReservation(id);
            return Ok();
        }

        [Authorize(Roles = Role.User + "," + Role.Business)]
        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            Reservation reservation = _reservationService.GetReservation(id);
            if (reservation == null)
                return BadRequest(new { message = "Reservation not found " });
            int userId = Convert.ToInt32(User.Identity.Name);

            if (User.IsInRole(Role.User))
            {
                if (reservation.UserId != userId)
                    return Unauthorized();
            }
            else
            {
                if (reservation.BusinessId == userId)
                    return Unauthorized();
            }

            return Ok(reservation);
        }

        [Authorize(Roles = Role.User + "," + Role.Business)]
        [HttpGet]
        public IActionResult GetReservations()
        {
            string role = User.IsInRole(Role.User) ? Role.User : Role.Business;
            try
            {
                ICollection<Reservation> reservations = _reservationService.GetReservations(Convert.ToInt32(User.Identity.Name), role);
                return Ok(reservations);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [Authorize(Roles = Role.User + "," + Role.Business)]
        [HttpGet("history")]
        public IActionResult GetPreviousReservations()
        {
            string role = User.IsInRole(Role.User) ? Role.User : Role.Business;
            try
            {
                ICollection<Reservation> reservations = _reservationService.GetOldReservations(Convert.ToInt32(User.Identity.Name), role);
                return Ok(reservations);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [Authorize(Roles = Role.Business)]
        [HttpPut("confirm/{id}")]
        public IActionResult ConfirmReservation(int id)
        {
            Reservation reservation = _reservationService.GetReservation(id);

            if (reservation.UserId == Convert.ToInt32(User.Identity.Name))
            {
                try
                {
                    _reservationService.ConfirmReservation(id);
                    return Ok();
                }
                catch(ValidationException ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
            else return Unauthorized();
        }
    }
}