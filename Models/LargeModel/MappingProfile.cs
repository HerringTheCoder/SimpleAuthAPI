using AutoMapper;

namespace SimpleAuthAPI.Models.LargeModel
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Test1, Test>();
            CreateMap<Test2, Test>();
        }
    }
}
