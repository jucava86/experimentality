using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autenticar([FromBody] AuthRequest model)
        {
            var userResponse = _userService.result(model);

            if (userResponse.Success) { 
                return Ok(userResponse);
            }
            else
            {
                return BadRequest(userResponse);
            }
        }
    }
}
