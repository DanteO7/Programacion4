using Auth.Models.User;
using Auth.Models.User.DTO;
using Auth.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Auth.Services
{
    public class AuthServices
    {
        private readonly UserServices _userServices;
        private readonly IEncoderServices _encoder;
        private readonly IConfiguration _configuration;
        internal readonly string _secret;
        public AuthServices(UserServices userServices, IEncoderServices encoder, IConfiguration configuration)
        {
            _userServices = userServices;
            _encoder = encoder;
            _configuration = configuration;
            _secret = _configuration.GetSection("Secrets:JWT")?.Value?.ToString() ?? string.Empty;
        }

        async public Task<User> Register(RegisterDTO register)
        {
            var user = await _userServices.GetOneByEmailOrUsername(register.Email, register.Username);
            if(user != null)
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "User with email or username already exists");
            }

            var createdUser = await _userServices.CreateOne(register);

            return createdUser;
        }

        async public Task<LoginResponseDTO> Login(LoginDTO login)
        {
            var datum = login.EmailOrUsername;
            var user = await _userServices.GetOneByEmailOrUsername(datum, datum);

            if (user == null)
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "Invalid credentials");
            }

            bool IsMatch = _encoder.Verify(login.Password, user.Password);

            if (!IsMatch)
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "Invalid credentials");
            }
            
            string token = GenerateJWT(user);

            return new LoginResponseDTO { Token = token };
        }

        public string GenerateJWT(User user)
        {
            var key = Encoding.UTF8.GetBytes(_secret);
            var symmertricKey = new SymmetricSecurityKey(key);

            var credentials = new SigningCredentials(symmertricKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim("id", user.Id.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(tokenConfig);

            return token;
        }
    }
}
