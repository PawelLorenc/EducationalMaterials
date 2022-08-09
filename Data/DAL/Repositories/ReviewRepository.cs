namespace Data.DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly EducationalMaterialContext _context;

        public ReviewRepository(EducationalMaterialContext context)
        {
            _context = context;
        }

        public void Create(Review review)
        {
            _context.Reviews.Add(review);
        }

        public void Delete(Review review)
        {
            _context.Reviews.Remove(review);
        }

        public async Task<Review> GetById(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(r => r.Id.Equals(id));
        }

        public async Task<List<Review>> GetReviewsByMaterialId(int id)
        {
            return await _context.Reviews
                .Where(x => x.MaterialNAvigationPointId == id)
                .ToListAsync();
        }

        public async Task<bool> IsExistingById(int reviewId)
        {
            return await _context.Reviews.AnyAsync(r => r.Id.Equals(reviewId));
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }
    }
}
