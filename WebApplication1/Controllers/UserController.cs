using Data.DAL.Interfaces;
using Data.DTO.UserDTO;

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
        public ActionResult RegisterUser([FromBody]RegisterUserDTO dto)
        {
             _userService.RegisterUser(dto);
            return Ok();
        }
        //[HttpPost("NewAdmin")]
        //public ActionResult AddAdmin[FromBody]RegisterUserDTO dto
    }
}
