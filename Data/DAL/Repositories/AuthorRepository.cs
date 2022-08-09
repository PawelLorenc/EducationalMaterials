namespace Data.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly EducationalMaterialContext _context;

        public AuthorRepository(EducationalMaterialContext context)
        {
            _context = context;
        }
        public async Task<bool> IsExistingById(int id)
        {
        return await _context.Authors
                .AnyAsync(author => author.Id.Equals(id));
        }
    }
}
