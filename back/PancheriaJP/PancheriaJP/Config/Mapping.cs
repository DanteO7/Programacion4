using AutoMapper;
using PancheriaJP.Models.Categoria;
using PancheriaJP.Models.Categoria.Dto;
using PancheriaJP.Models.Ingrediente;
using PancheriaJP.Models.Ingrediente.Dto;
using PancheriaJP.Models.Pancho;
using PancheriaJP.Models.Pancho.Dto;

namespace PancheriaJP.Config
{
    public class Mapping : Profile
    {
        public Mapping()
        {

            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<List<string>?, List<string>>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<Pancho, PanchosDTO>();
            CreateMap<Pancho, PanchoDTO>().ReverseMap();
            CreateMap<Pancho, PanchoAderezoDTO>();

            CreateMap<CreatePanchoDTO, Pancho>().ReverseMap();

            CreateMap<UpdatePanchoDTO, Pancho>().ForAllMembers(opts =>
            {
                opts.Condition((_, _, srcMember) => srcMember != null);
            });

            CreateMap<CreateUpdateIngredienteDTO, Ingrediente>();
            CreateMap<CreateUpdateCategoriaDTO, Categoria>();
        }
    }
}
