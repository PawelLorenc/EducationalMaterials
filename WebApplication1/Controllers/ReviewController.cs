namespace Api.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        [Route("{materialId}")]
        public async Task<ActionResult<List<ReviewDTO>>> GetByMaterialId([FromRoute]int materialId)
        {
            if (!await _reviewService.ValidateMaterialId(materialId))
            {
                return NotFound("Material does not exist");
            }
            var result = await _reviewService.GetReviews(materialId);
            return Ok(result);
        }
        [HttpPost]
        [Route("{materialId}")]
        public async Task<IActionResult> CreateReview([FromBody]ReviewDTO body, [FromRoute] int materialId)
        {
            if (!await _reviewService.ValidateMaterialId(materialId))
            {
                return NotFound("Material does not exist");
            }
            await _reviewService.CreateReview(body, materialId);
            return Ok("Review created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewDTO body)
        {
            if (!await _reviewService.ValidateReviewId(body.id))
            {
                return NotFound("Review does not exist");
            }
            await _reviewService.UpdateReview(body);
            return Ok("Review updated");
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _reviewService.ValidateReviewId(id))
            {
                return NotFound("Review does not exist");
            }
            await _reviewService.DeleteReview(id);
            return Ok("Review deleted");
        }
    }
}
