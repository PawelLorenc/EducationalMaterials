using AutoMapper;

namespace Api.Services
{
    public class MaterialTypeService : IMaterialTypeService
    {
        private readonly IMaterialTypeRepository _materialTypeRepo;
        private readonly IMapper _mapper;

        public MaterialTypeService(IMapper mapper, IMaterialTypeRepository materialTypeRepo)
        {
            _mapper = mapper;
            _materialTypeRepo = materialTypeRepo;
        }
        public async Task<List<MaterialType>> GetAll()
        {
            var Materials = await _materialTypeRepo.GetAll();
            var MaterialDto = _mapper.Map<List<MaterialType>>(Materials);
            return MaterialDto;
        }
    }
}
