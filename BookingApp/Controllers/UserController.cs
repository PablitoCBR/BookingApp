using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Dtos.Accounts;
using BookingApp.Entities.Accounts;
using BookingApp.Interfaces.Services.Accounts;
using AutoMapper;
using BookingApp.Security;
using BookingApp.Exceptions;
using System;

namespace BookingApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly JWTProvider _jwtProvider;

        public UserController(IUserService userService, IMapper mapper, JWTProvider jwtProvider)
        {
            _userService = userService;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Email, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect!" });

            string token = _jwtProvider.GetJWT(user.Id);

            return Ok(new
            {
                user.Id,
                user.Email,
                user.Name,
                user.Surname,
                token
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            try
            {
                _userService.Create(user, userDto.Password);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (Convert.ToInt32(User.Identity.Name) != id)
                return Unauthorized();

            try
            {
                UserDto user = _userService.GetById(id);
                return Ok(user);
            }
            catch(ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserDto userDto)
        {
            if (Convert.ToInt32(User.Identity.Name) != id)
                return Unauthorized();

            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            try
            {
                _userService.Update(user, userDto.Password);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (Convert.ToInt32(User.Identity.Name) != id)
                return Unauthorized();

            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
