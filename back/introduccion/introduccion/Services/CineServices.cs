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
        void DeleteOne(int id);
    }
    public class CineServices : ICineServices
    {
        private static List<Cine> _cines = new() {
            new() { Id=1,Name="Cinemark",IsOpen=true },
            new(){ Id=2,Name="ShowCase",IsOpen=true},
            new(){ Id=3,Name="CinePolis",IsOpen=false},
            new(){ Id=4,Name="Hoyts",IsOpen=true}
        };
        
        public List<CinesDTO> GetAll()
        {
            return _cines.Select(c =>
            {
                return new CinesDTO() { Id = c.Id, Name = c.Name };
            }).ToList();
        }

        public Cine GetOneById(int id)
        {
            var cine = _cines.FirstOrDefault(c=> c.Id == id);
            if (cine != null)
            {
                return cine;
            }
            else
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No se encontro el cine con ID = {id}");
            }
        }

        public Cine CreateOne(CreateCineDTO createCineDTO)
        {
            int lastId = _cines.Last().Id;

            if(createCineDTO.Name.Trim().Length > 30)
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "El nombre no puede contener mas de 30 carateres");
            }

            var cine = new Cine()
            {
                Id = lastId + 1,
                Name = createCineDTO.Name,
                Description = createCineDTO.Description,
                IsOpen = createCineDTO.IsOpen,
            };

            _cines.Add(cine);

            return cine;
        }

        public void DeleteOne(int id)
        {
            var cine = _cines.FirstOrDefault(c => c.Id == id);
            if (cine != null)
            {
                _cines.Remove(cine);
            }
            else
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No se encontro el cine con ID = {id}");
            }
        }
    }
}