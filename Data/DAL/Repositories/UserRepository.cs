using Data.DTO.UserDTO;

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
        public User? GetByEmail(string email)
        {
            return _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
