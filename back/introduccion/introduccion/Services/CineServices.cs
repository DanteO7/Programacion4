using AutoMapper;
using introduccion.Models.Cine;
using introduccion.Models.Cine.DTO;
using introduccion.Utils;
using System.Net;

namespace introduccion.Servicios
{
    public interface ICineServices
    {
        List<CinesDTO> GetAll();
        Cine GetOneById(int id);
        Cine CreateOne(CreateCineDTO createCineDTO);
        void DeleteOneById(int id);
        Cine UpdateOneById(int id, UpdateCineDTO updateCineDTO);
    }
    public class CineServices : ICineServices
    {
        private readonly IMapper _mapper;
        public CineServices(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Cine> _cines = new() {
            new() { Id=1,Name="Cinemark",IsOpen=true },
            new(){ Id=2,Name="ShowCase",IsOpen=true},
            new(){ Id=3,Name="CinePolis",IsOpen=false},
            new(){ Id=4,Name="Hoyts",IsOpen=true}
        };
        
        private Cine GetOneByIdOrException(int id)
        {
            var cine = _cines.FirstOrDefault(c => c.Id == id);
            if (cine == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No se encontro el cine con ID = {id}");
            }
            return cine;
        }

        public List<CinesDTO> GetAll() => _mapper.Map<List<CinesDTO>>(_cines);

        public Cine GetOneById(int id) => GetOneByIdOrException(id);

        public Cine CreateOne(CreateCineDTO createCineDTO)
        {
            int lastId = _cines.Last().Id;

            var cine = _mapper.Map<Cine>(createCineDTO);

            cine.Id = lastId + 1;

            _cines.Add(cine);

            return cine;
        }

        public void DeleteOneById(int id)
        {
            var cine = GetOneByIdOrException(id);
            _cines.Remove(cine);
        }

        public Cine UpdateOneById(int id, UpdateCineDTO updateCineDTO)
        {
            var cine = GetOneByIdOrException(id);

            var cineMapped = _mapper.Map(updateCineDTO, cine);

            return cineMapped;
        }
    }
}