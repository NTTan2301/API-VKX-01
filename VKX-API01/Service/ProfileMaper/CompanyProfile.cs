using AutoMapper;
using VKX_API01.Models;
using VKX_API01.Service.Dto.Company;

namespace VKX_API01.Service.ProfileMaper
{
    public class CompanyEntityToDtoProfile : Profile
    {
        public CompanyEntityToDtoProfile()
        {
            CreateMap<Company, CompanyGridDto>();
            CreateMap<Company, CompanyCreateDto>();
            CreateMap<Company, CompanyUpdateDto>();
            CreateMap<Company, CompanyDetailDto>();
        }
    }
    public class CompanyDtoToEntityProfile : Profile
    {
        public CompanyDtoToEntityProfile()
        {
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<CompanyUpdateDto, Company>();
            CreateMap<CompanyDetailDto, Company>();
            CreateMap<CompanyGridDto, Company>();
        }
    }
}
