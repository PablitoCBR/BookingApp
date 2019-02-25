using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Entities.Accounts;
using BookingApp.Interfaces.Services.Accounts;
using AutoMapper;
using BookingApp.Security;
using BookingApp.Dtos.Accounts;

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
        public IActionResult Authenticate([FromBody]BusinessDto bussines)
        {
            throw new System.NotImplementedException();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]BusinessDto business)
        {
            throw new System.NotImplementedException();
        }


    }
}