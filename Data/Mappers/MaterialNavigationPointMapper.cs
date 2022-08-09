using Data.DTO.UserDTO.CreateDTO;

namespace Data.Mappers
{
    public class MaterialNavigationPointMapper : Profile
    {
        public MaterialNavigationPointMapper()
        {
            CreateMap<MaterialNavigationPoint, MaterialNavigationPointDto>()
            .ForMember(a => a.Author, c => c.MapFrom(s => s.Author.Name))
            .ForMember(a => a.MaterialType, c => c.MapFrom(s => s.MaterialType.Name))
            .ForMember(a => a.Reviews, c => c.MapFrom(s => s.Reviews.ConvertAll<string>(x => x.TextReview)));

            CreateMap<CreateMaterialNavigationDto, MaterialNavigationPoint>();
        }
    }
}
