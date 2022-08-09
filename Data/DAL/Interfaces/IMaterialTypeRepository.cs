namespace Data.DAL.Interfaces
{
    public interface IMaterialTypeRepository
    {
        public Task<bool> IsExistingById(int id);
        public Task<List<MaterialType>> GetAll();
    }
}
