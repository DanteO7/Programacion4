using AutoMapper;
using PancheriaJP.Utils;
using PancheriaJP.Models.Categoria;
using PancheriaJP.Models.Categoria.Dto;
using PancheriaJP.Repositories;
using System.Net;

namespace PancheriaJP.Services
{
    public class CategoriaServices
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _repo;
        public CategoriaServices(IMapper mapper, ICategoriaRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        async private Task<Categoria> GetOneByIdOrException(int id)
        {
            var cat = await _repo.GetOne(p => p.Id == id);
            if (cat == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No hay Categoria con id = {id}");
            }
            return cat;
        }

        async public Task<List<Categoria>> GetAll()
        {
            var cats = await _repo.GetAll();
            return cats.ToList();
        }

        async public Task<Categoria> GetOneById(int id) => await GetOneByIdOrException(id);

        async public Task<Categoria> CreateOne(CreateUpdateCategoriaDTO createDTO)
        {
            var cat = _mapper.Map<Categoria>(createDTO);

            await _repo.CreateOne(cat);

            return cat;
        }

        async public Task<Categoria> UpdateOneById(int id, CreateUpdateCategoriaDTO updateDTO)
        {
            var cat = await GetOneByIdOrException(id);

            var catMapped = _mapper.Map(updateDTO, cat);

            await _repo.UpdateOne(catMapped);

            return catMapped;
        }

        async public Task DeleteOneById(int id)
        {
            var cat = await GetOneByIdOrException(id);
            await _repo.DeleteOne(cat);
        }
    }
}
