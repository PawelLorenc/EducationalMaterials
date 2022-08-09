namespace Api.Services.Interfaces
{
    public interface IReviewService
    {
        Task<List<ReviewDTO>> GetReviews(int id);
        Task CreateReview(ReviewDTO dto, int materialId);
        Task<bool> ValidateMaterialId(int materialId);
        Task UpdateReview(ReviewDTO body);
        Task<bool> ValidateReviewId(int id);
        Task DeleteReview(int id);
    }
}
