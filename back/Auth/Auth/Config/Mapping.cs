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
        }
    }
}
