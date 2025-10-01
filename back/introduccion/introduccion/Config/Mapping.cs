using AutoMapper;
using introduccion.Models.Cine;
using introduccion.Models.Cine.DTO;

// nos dice de que entidad mapear a que otra entidad

namespace introduccion.Config
{
    public class Mapping : Profile
    {
        
        public Mapping()
        {
            // default values when source is null
            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest); 
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);

            // mapeo unidireccional
            CreateMap<Cine, CinesDTO>();

            // mapeo bidireccional
            CreateMap<CreateCineDTO, Cine>().ReverseMap();

            // no mapear los nulos
            CreateMap<UpdateCineDTO, Cine>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
        }
    }
}
