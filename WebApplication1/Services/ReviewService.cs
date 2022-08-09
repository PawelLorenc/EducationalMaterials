namespace Api.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepo;
        private readonly IMaterialTypeRepository _materialTypeRepository;

        public ReviewService(IReviewRepository reviewRepo, IMapper mapper, IMaterialTypeRepository materialTypeRepository)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
            _materialTypeRepository = materialTypeRepository;
        }

        public async Task<bool> ValidateReviewId(int reviewId)
        {
            return await _reviewRepo.IsExistingById(reviewId);
        }

        public async Task<bool> ValidateMaterialId(int materialId)
        {
            return await _materialTypeRepository.IsExistingById(materialId);
        }

        public async Task<List<ReviewDTO>> GetReviews(int materialId)
        {
            var reviewList = await _reviewRepo.GetReviewsByMaterialId(materialId);
            var reviewListDto = _mapper.Map<List<ReviewDTO>>(reviewList);
            return reviewListDto;
        }
        public async Task CreateReview(ReviewDTO dto, int materialId)
        {
            var review = _mapper.Map<Review>(dto);
            review.MaterialNAvigationPointId = materialId;
            _reviewRepo.Create(review);
            await _reviewRepo.SaveAsync();
        }

        public async Task UpdateReview(ReviewDTO dto)
        {
            var review = await _reviewRepo.GetById(dto.id);
            if (review != null)
            {
                _mapper.Map(dto, review);
                _reviewRepo.Update(review);
                await _reviewRepo.SaveAsync();
            }
        }

        public async Task DeleteReview(int id)
        {
            var review = await _reviewRepo.GetById(id);
            _reviewRepo.Delete(review);
            await _reviewRepo.SaveAsync();
        }
    }
}
