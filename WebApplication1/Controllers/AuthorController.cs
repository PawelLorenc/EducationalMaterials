namespace Api.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<List<AuthorDto>>> GetAll()
        {
            var authorDto = await _authorService.GetAll();
            return Ok(authorDto);
        }

    }
}
