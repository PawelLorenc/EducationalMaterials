namespace Data.DAL.Repositories
{
    public class MaterialNavigationPointRepository : IMaterialNavigationPointRepository
    {
        private readonly EducationalMaterialContext _context;

        public MaterialNavigationPointRepository(EducationalMaterialContext context)
        {
            _context = context;
        }

        public async Task<List<MaterialNavigationPoint>> GetAll()
        {
            return await _context.MaterialNavigationPoints
                .Include(a => a.Author)
                .Include(b => b.MaterialType)
                .Include(c => c.Reviews)
                .ToListAsync();
        }
        public void Delete(MaterialNavigationPoint entity)
        {
            _context.MaterialNavigationPoints.Remove(entity);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<MaterialNavigationPoint?> GetById(int id)
            => await _context.MaterialNavigationPoints
            .Include(a => a.Author)
            .Include(b => b.MaterialType)
            .Include(c => c.Reviews)
            .FirstOrDefaultAsync(x => x.Id == id);

        public void Create(MaterialNavigationPoint entity)
        {
            _context.Add(entity);
        }

        public void Update(MaterialNavigationPoint entity)
        {
            _context.Update(entity);
        }

        public async Task<IEnumerable<MaterialNavigationPoint>> GetByAuthorIdWithMinAverageReview(int authorId, double minAverageReview)
        {
            return await _context.MaterialNavigationPoints
                .Include(a => a.Author)
                .Include(b => b.MaterialType)
                .Include(c => c.Reviews)
                .Where(m => m.AuthorId.Equals(authorId)
                    && m.Reviews.Average(r => r.PointReview) > minAverageReview)
                .ToListAsync();
        }

        public async Task<IEnumerable<MaterialNavigationPoint>> GetByMaterialTypeId(int materialTypeId)
        {
            return await _context.MaterialNavigationPoints
                .Include(a => a.Author)
                .Include(b => b.MaterialType)
                .Include(c => c.Reviews)
                .Where(m => m.MaterialTypeId.Equals(materialTypeId))
                .ToListAsync();
        }
    }
}
