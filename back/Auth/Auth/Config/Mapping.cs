using Auth.Models.User;
using Auth.Models.User.DTO;
using AutoMapper;

namespace Auth.Config
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Defaults
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);

            // Auth
            CreateMap<RegisterDTO, User>();

            CreateMap<User, UserWithoutPassDTO>().ForMember(
                dest => dest.Roles,
                opt => opt.MapFrom(
                    src => src.Roles.Select(r => r.Name).ToList()
                )
            );
        }
    }
}
