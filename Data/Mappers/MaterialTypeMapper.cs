namespace Data.Mappers
{
    public class MaterialTypeMapper : Profile
    {
        public MaterialTypeMapper()
        {
            CreateMap<MaterialType, MaterialTypeDto>();
        }
    }
}
