using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.UserModel;
using Services.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController: Controller
    {
        private IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost("register",Name ="register")]
        public async Task<IActionResult> Register([FromBody] UserForRegister user)
        {
            try
            {
                var isRegistered = await _service.Register(user);

                if (isRegistered.Succeeded)
                    return Created("register", isRegistered);


                return StatusCode(500, isRegistered.Errors);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpPost("login", Name = "login")]
        public async Task<IActionResult> Login([FromBody] UserForLogin user)
        {
            try
            {
                var isOk = await _service.Login(user);

                if (isOk != null)
                    return Ok(isOk);


                return BadRequest("Username or password incorect");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }
    }
}
