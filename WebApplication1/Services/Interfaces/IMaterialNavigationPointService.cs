

namespace Api.Services.Interfaces
{
    public interface IMaterialNavigationPointService
    {
        public Task<IEnumerable<MaterialNavigationPointDto>> GetAll();
        public Task<bool> Delete(int id);
        public Task<bool> Create(CreateMaterialNavigationDto dto);
        Task<bool> ValidateMaterialId(int id);
        Task<bool> ValidateAuthorId(int id);
        Task<bool> ValidateMaterialTypeId(int materialTypeId);
        Task<bool> Update(int id, CreateMaterialNavigationDto dto);
        Task<IEnumerable<MaterialNavigationPointDto>> GetTopRatedMaterialsForAuthor(int authorId);
        Task<IEnumerable<MaterialNavigationPointDto>> GetMaterialsByMaterialType(int materialTypeId);
    }
}
