using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Entities.Accounts;
using BookingApp.Interfaces.Services.Accounts;
using AutoMapper;
using BookingApp.Security;
using BookingApp.Dtos.Accounts;
using BookingApp.Exceptions;
using System;

namespace BookingApp.Controllers
{
    [Authorize(Roles = Role.Business)]
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _businessService;
        private readonly IMapper _mapper;
        private readonly JWTProvider _jwtProvider;

        public BusinessController(IBusinessService businessService, IMapper mapper, JWTProvider jwtProvider)
        {
            _businessService = businessService;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]BusinessDto businesDto)
        {
<<<<<<< HEAD
            Business business = _businessService.Authenticate(businesDto.Email, businesDto.Password);

            if (business == null)
                return BadRequest(new { message = "Username or password is incorrect!" });

            string token = _jwtProvider.GetJWT(business.Id, Role.Business);

            return Ok(new
            {
                business.Id,
                business.CompanyName,
                business.Email,
                business.Address,
                token
            });
=======
            throw new System.NotImplementedException();
>>>>>>> USerServiceTest
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]BusinessDto businessDto)
        {
            Business business = _mapper.Map<Business>(businessDto);
            try
            {
                _businessService.Create(business, businessDto.Password);
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
                BusinessDto businessDto = _businessService.Get(id);
                return Ok(businessDto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]BusinessDto businessDto)
        {
<<<<<<< HEAD
            if (Convert.ToInt32(User.Identity.Name) != id)
                return Unauthorized();

            Business business = _mapper.Map<Business>(businessDto);
            business.Id = id;

            try
            {
                _businessService.Update(business, businessDto.Password);
                return Ok();
            }
            catch(ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
=======
            throw new System.NotImplementedException();
>>>>>>> USerServiceTest
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (Convert.ToInt32(User.Identity.Name) != id)
                return Unauthorized();

            try
            {
                _businessService.Delete(id);
                return Ok();
            }
            catch(ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}