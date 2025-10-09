using PancheriaJP.Config;
using PancheriaJP.Models.Categoria;
using PancheriaJP.Models.Ingrediente;

namespace PancheriaJP.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria> { }
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
