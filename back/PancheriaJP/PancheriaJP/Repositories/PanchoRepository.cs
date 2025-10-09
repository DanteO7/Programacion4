using Microsoft.EntityFrameworkCore;
using PancheriaJP.Config;
using PancheriaJP.Models.Pancho;
using System.Linq;
using System.Linq.Expressions;

namespace PancheriaJP.Repositories
{
    public interface IPanchoRepository : IRepository<Pancho> {}
    public class PanchoRepository : Repository<Pancho>, IPanchoRepository
    {
        private readonly ApplicationDbContext _db;

        public PanchoRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        async new public Task<Pancho> GetOne(Expression<Func<Pancho, bool>>? filter = null)
        {
            IQueryable<Pancho> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter).Include(x => x.Categoria).Include(x=>x.Ingredientes);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
