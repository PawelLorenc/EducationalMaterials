namespace Data.DAL.Repositories
{    public class MaterialTypeRepository : IMaterialTypeRepository
    {
        private readonly EducationalMaterialContext _context;
        public MaterialTypeRepository(EducationalMaterialContext context)
        {
            _context = context;
        }

        public async Task<bool> IsExistingById(int id)
        {
            return await _context.MaterialTypes
                    .AnyAsync(m => m.Id.Equals(id));
        }
        public async Task<List<MaterialType>> GetAll()
        {
            return await _context.MaterialTypes
                .ToListAsync();
        }
    }
}
