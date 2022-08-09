using AutoMapper;
using Data.DTO;
using Data.DTO.UserDTO.CreateDTO;
using Data.Entities;

namespace Api.Services
{
    public class MaterialNavigationPointService : IMaterialNavigationPointService
    {
        private readonly IMaterialNavigationPointRepository _materialRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IMaterialTypeRepository _materialTypeRepo;
        private readonly IMapper _mapper;

        public MaterialNavigationPointService(IMaterialNavigationPointRepository materialRepo, IMapper mapper, IAuthorRepository authorRepo, IMaterialTypeRepository materialTypeRepo)
        {
            _materialRepo = materialRepo;
            _mapper = mapper;
            _authorRepo = authorRepo;
            _materialTypeRepo = materialTypeRepo;
        }

        public async Task<IEnumerable<MaterialNavigationPointDto>> GetAll()
        {
            var materialNavigation = await _materialRepo.GetAll();
            var materialNavigationDto = _mapper.Map<List<MaterialNavigationPointDto>>(materialNavigation);
            return materialNavigationDto;
        }
        public async Task<bool> Delete(int id)
        {
            var materialToDelete = await _materialRepo.GetById(id);
            if (materialToDelete == null) return false;
           
            _materialRepo.Delete(materialToDelete);
            await _materialRepo.Save();
            return true; 
        }
        public async Task<bool> Create(CreateMaterialNavigationDto dto)
        {
            if (await ValidateNavigableProperties(dto))
            {
                var materialNavigation = _mapper.Map<MaterialNavigationPoint>(dto);
                _materialRepo.Create(materialNavigation);
                await _materialRepo.Save();
                return true;
            }
            return false;
        }

        private async Task<bool> ValidateNavigableProperties(CreateMaterialNavigationDto dto)
        {
            var isAuthorValid = await ValidateAuthorId(dto.AuthorId);
            var isMaterialTypeValid = await ValidateMaterialTypeId(dto.MaterialTypeId);
            return isAuthorValid && isMaterialTypeValid;
        }

        public async Task<bool> ValidateMaterialId(int id)
        {
            return await _materialRepo.GetById(id) != null;
        }

        public async Task<bool> ValidateAuthorId(int id)
        {
            return await _authorRepo.IsExistingById(id);
        }

        public async Task<bool> ValidateMaterialTypeId(int materialTypeId)
        {
            return await _materialTypeRepo.IsExistingById(materialTypeId);
        }
        public async Task<bool> Update(int id, CreateMaterialNavigationDto dto)
        {
            if (await ValidateNavigableProperties(dto))
            {
                var materialToUpdate = await _materialRepo.GetById(id);
                _mapper.Map(dto, materialToUpdate);
                _materialRepo.Update(materialToUpdate);
                await _materialRepo.Save();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<MaterialNavigationPointDto>> GetTopRatedMaterialsForAuthor(int authorId)
        {
            var materialNavigation = await _materialRepo.GetByAuthorIdWithMinAverageReview(authorId, 5.0);
            var materialNavigationDto = _mapper.Map<List<MaterialNavigationPointDto>>(materialNavigation);
            return materialNavigationDto;
        }


        public async Task<IEnumerable<MaterialNavigationPointDto>> GetMaterialsByMaterialType(int materialTypeId)
        {
            var materialNavigation = await _materialRepo.GetByMaterialTypeId(materialTypeId);
            var materialNavigationDto = _mapper.Map<List<MaterialNavigationPointDto>>(materialNavigation);
            return materialNavigationDto;
        }
    }
}
