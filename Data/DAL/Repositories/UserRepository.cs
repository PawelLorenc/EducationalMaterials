namespace Data.DAL.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly EducationalMaterialContext _context;

        public UserRepository(EducationalMaterialContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void Add(User entity)
        {
            _context.Add(entity);
        }
    }
}
