using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForCtorParam("UserId", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("Token", opt => opt.MapFrom(src => (string?)null))
                .ForCtorParam("Success", opt => opt.MapFrom(src => true));

            CreateMap<RegisterRequest, ApplicationUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));

            CreateMap<ApplicationUser, User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
        }
    }
}
