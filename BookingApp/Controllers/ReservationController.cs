using BookingApp.Entities.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        [Authorize(Roles = Role.User)]
        [HttpPost("make")]
        public IActionResult MakeReservation()
        {
            return Ok();
        }

        [Authorize(Roles = Role.User + "," + Role.Business)]
        [HttpDelete("cancel/{id}")]
        public IActionResult CancelReservation()
        {
            // user can cancel his reservation or bussiness providing service
            return Ok();
        }

        [Authorize(Roles = Role.User + "," + Role.Business)]
        [HttpGet("{id}")]
        public IActionResult GetReservation()
        {
            // get reservation id with user id
            return Ok();
        }

        [Authorize(Roles = Role.User + "," + Role.Business)]
        [HttpGet]
        public IActionResult GetReservations()
        {
            return Ok(); // will resturn list of user/business reservations from current date
        }

        [Authorize(Roles = Role.User + "," + Role.Business)]
        [HttpGet("history")]
        public IActionResult GetPreviousReservations()
        {
            return Ok(); // will resturn list of user/business reservations before current date
        }

        [Authorize(Roles = Role.Business)]
        [HttpPut("confirm/{id}")]
        public IActionResult ConfirmReservation()
        {
            return Ok();
        }
    }
}