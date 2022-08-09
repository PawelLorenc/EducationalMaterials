namespace Api.Controllers
{
    [Route("api/materialtype")]
    [ApiController]
    public class MaterialTypeController : ControllerBase
    {
        private readonly IMaterialTypeService _materialTypeService;

        public MaterialTypeController(IMaterialTypeService materialTypeService)
        {
            _materialTypeService = materialTypeService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<List<MaterialTypeDto>>> GetAll()
        {
            var MaterialDto = await _materialTypeService.GetAll();
            return Ok(MaterialDto);
        }
    }
}
