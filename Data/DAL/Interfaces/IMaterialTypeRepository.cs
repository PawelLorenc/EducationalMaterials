namespace Data.DAL.Interfaces
{
    public interface IMaterialTypeRepository
    {
        public Task<bool> IsExistingById(int id);
    }
}
