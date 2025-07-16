using ecommerce.Core.DTO;
using ecommerce.Core.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("register")]
        [HttpPost]
       public async Task<IActionResult> Register(RegisterRequest obj)
       {
            if(obj== null)
            {
                return BadRequest("Invalid Registration Data");
            }


            //Call the user Service to handle registration

            var Authresponse  =  await _userService.Register(obj);

            if(Authresponse == null || !Authresponse.Success)
            {
                return BadRequest(Authresponse);
            }

            return Ok(Authresponse);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult>  Login(LoginRequest obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid Login Data");
            }


            //Call the user Service to handle registration

            var Loginresponse = await _userService.Login(obj);

            if (Loginresponse == null || !Loginresponse.Success)
            {
                return Unauthorized(Loginresponse);
            }

            return Ok(Loginresponse);
        }
    }
}
