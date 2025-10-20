using Auth.Config;
using Auth.Models.Role;

namespace Auth.Repositories
{
    public interface IRoleRepository : IRepository<Role> { };
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public RoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
