namespace Api.Services.Interfaces
{
    public interface IMaterialTypeService
    {
        public Task<List<MaterialType>> GetAll();
    }
}
