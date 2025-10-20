using Auth.Models.User;
using Auth.Models.User.DTO;
using Auth.Repositories;
using Auth.Utils;
using AutoMapper;
using System.Net;

namespace Auth.Services
{
    public class UserServices
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        private readonly IEncoderServices _encoder;
        public UserServices(IUserRepository repo, IMapper mapper, IEncoderServices encoder)
        {
            _repo = repo;
            _mapper = mapper;
            _encoder = encoder;
        }

        async public Task<User> GetOneByEmailOrUsername(string? email, string? username)
        {
            User user;
            if (!string.IsNullOrEmpty(email))
            {
                user = await _repo.GetOneAsync(u => u.Email == email);
            }
            else if (!string.IsNullOrEmpty(username))
            {
                user = await _repo.GetOneAsync(u => u.Username == email);
            }
            else
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "Email or Username are empty");
            }

            return user;
        }

        async public Task<User> CreateOne(RegisterDTO register)
        {
            var user = _mapper.Map<User>(register);

            user.Password = _encoder.Encode(user.Password);

            await _repo.CreateOneAsync(user);

            return user;
        }
    }
}
