using System.Threading.Tasks;
using Data;
using Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;
        public AuthController(IAuthRepository auth)
        {
            _auth = auth;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(UserRegistrationDto user)
        {
            ServiceResponse<int> res = await _auth.Register(
                new User { Username = user.Username } , user.Password);
                if(!res.Success)
                {
                    return BadRequest(res);
                }
                return Ok(res);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(UserLoginDto user)
        {
            ServiceResponse<string> res = await _auth.Login(user.Username , user.Password);
            if(!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}