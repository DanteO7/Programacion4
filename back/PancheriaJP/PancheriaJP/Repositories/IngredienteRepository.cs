using PancheriaJP.Config;
using PancheriaJP.Models.Ingrediente;

namespace PancheriaJP.Repositories
{
    public interface IIngredienteRepository : IRepository<Ingrediente> { }
    public class IngredienteRepository : Repository<Ingrediente>, IIngredienteRepository
    {
        private readonly ApplicationDbContext _db;
        public IngredienteRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
    }
}
