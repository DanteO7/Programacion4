using AutoMapper;
using PancheriaJP.Utils;
using PancheriaJP.Models.Ingrediente;
using PancheriaJP.Models.Ingrediente.Dto;
using PancheriaJP.Repositories;
using System.Net;
using PancheriaJP.Models.Pancho.Dto;

namespace PancheriaJP.Services
{
    public class IngredienteServices
    {
        private readonly IMapper _mapper;
        private readonly IIngredienteRepository _repo;
        public IngredienteServices(IMapper mapper, IIngredienteRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        async private Task<Ingrediente> GetOneByIdOrException(int id)
        {
            var ing = await _repo.GetOne(p => p.Id == id);
            if (ing == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No hay ingrediente con id = {id}");
            }
            return ing;
        }

        async public Task<List<Ingrediente>> GetAll()
        {
            var ings = await _repo.GetAll();
            return ings.ToList();
        }

        async public Task<Ingrediente> GetOneById(int id) => await GetOneByIdOrException(id);

        async public Task<Ingrediente> CreateOne(CreateUpdateIngredienteDTO createDTO)
        {
            var ing = _mapper.Map<Ingrediente>(createDTO);

            await _repo.CreateOne(ing);

            return ing;
        }

        async public Task<Ingrediente> UpdateOneById(int id, CreateUpdateIngredienteDTO updateDTO)
        {
            var ing = await GetOneByIdOrException(id);

            var ingMapped = _mapper.Map(updateDTO, ing);

            await _repo.UpdateOne(ingMapped);

            return ingMapped;
        }

        async public Task DeleteOneById(int id)
        {
            var ing = await GetOneByIdOrException(id);
            await _repo.DeleteOne(ing);
        }

        internal async Task<List<Ingrediente>> GetManyByIds(List<int> Ids)
        {
            if(Ids.Count <= 0 || Ids == null)
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "La lista de Ids esta vacia");
            }
            var ings = await _repo.GetAll(x=> Ids.Contains(x.Id));
            return ings.ToList();
        }
    }
}
