namespace Data.DAL.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<bool> IsExistingById(int id);
        public Task<List<Author>> GetAll();
    }
}
