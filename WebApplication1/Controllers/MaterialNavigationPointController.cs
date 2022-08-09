namespace Api.Controllers
{
    [Route("api/materialNavigation")]
    [ApiController]
    public class MaterialNavigationPointController : ControllerBase
    {
        private readonly IMaterialNavigationPointService _materialNavService;

        public MaterialNavigationPointController(IMaterialNavigationPointService materialNav)
        {
            _materialNavService = materialNav;
        }

        [HttpGet]
        public async Task<ActionResult<List<MaterialNavigationPointDto>>> GetAll()
        {
            var MaterialDto = await _materialNavService.GetAll();
            return Ok(MaterialDto);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _materialNavService.Delete(id);
            if (result == false) return NotFound();
            return Ok("The changes have passed successfully");
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([FromBody] CreateMaterialNavigationDto dto)
        {
            var result = await _materialNavService.Create(dto);
            if (result == false) return BadRequest("Author or MaterialType were not found");
            return Ok("Material Navigation successfully created");
        }
        [HttpPatch]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromBody] CreateMaterialNavigationDto dto, [FromRoute] int id)
        {
            var isIdValid = await _materialNavService.ValidateMaterialId(id);
            if (isIdValid)
            {
                var result = await _materialNavService.Update(id, dto);
                if (result == false) return BadRequest("Author or MaterialType were not found");
                return Ok("Material Navigation successfully created");
            }
            else
            {
                return NotFound("Material with given id was not found");
            }
        }

        [HttpGet]
        [Route("author/{authorId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<MaterialNavigationPointDto>>> GetTopRatedMaterialsForAuthor([FromRoute] int authorId)
        {
            var isAuthorValid = await _materialNavService.ValidateAuthorId(authorId);
            if (isAuthorValid)
            {
                var MaterialDto = await _materialNavService.GetTopRatedMaterialsForAuthor(authorId);
                return Ok(MaterialDto);
            }
            else
            {
                return NotFound("Authod with given id does not exist");
            }
        }
        [HttpGet]
        [Route("type/{materialTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<MaterialNavigationPointDto>>> GetMaterialsByMaterialType([FromRoute] int materialTypeId)
        {
            var isIdValid = await _materialNavService.ValidateMaterialTypeId(materialTypeId);
            if (isIdValid)
            {
                var MaterialDto = await _materialNavService.GetMaterialsByMaterialType(materialTypeId);
                return Ok(MaterialDto);
            }
            else
            {
                return NotFound("Material type with given id does not exist");
            }
        }
    }
}
