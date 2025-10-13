using Auth.Config;
using Auth.Models.User;

namespace Auth.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
    }
    public class UserRepository : Repository<User>, IUserRepository   
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
