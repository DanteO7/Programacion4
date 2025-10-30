using Auth.Models.Role;
using Auth.Repositories;
using Auth.Utils;
using System.Net;

namespace Auth.Services
{
    public class RoleServices
    {
        private readonly IRoleRepository _repo;
        public RoleServices(IRoleRepository repo)
        {
            _repo = repo;
        }

        public async Task<Role> GetOneByName(string name)
        {
            var role = await _repo.GetOneAsync(r => r.Name == name);
            if(role == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"Role with name: '{name}' does not exist");
            }
            return role;
        }
    }
}
