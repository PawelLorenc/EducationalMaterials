namespace Data.DAL.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewsByMaterialId(int materialId);

        Task<Review> GetById(int id);

        void Create(Review review);

        void Update(Review review);

        void Delete(Review id);

        Task SaveAsync();
        Task<bool> IsExistingById(int reviewId);
    }
}
