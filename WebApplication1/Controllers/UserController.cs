using Data.DAL.Interfaces;
using Data.DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public ActionResult RegisterUser([FromBody]RegisterUserDTO dto)
        {
             _userService.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _userService.Login(dto);

            if (token != null) {
                return Ok(token);
            }

            return NotFound("Incorrect username or password");
        }

    }
}
