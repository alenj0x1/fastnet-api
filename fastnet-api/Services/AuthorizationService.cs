using fastnet_api.DBModels;
using fastnet_api.Models.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace fastnet_api.Services
{
    public class AuthorizationService: IAuthService
    {
        private readonly FastnetdbContext _context;
        private readonly IConfiguration _configuration;

        public AuthorizationService(FastnetdbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string generateToken(string userId)
        {
            string key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId));

            var credentialsToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentialsToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string createdToken = tokenHandler.WriteToken(tokenConfig);

            return createdToken;
        }

        public async Task<LoginResponse> ReturnToken(LoginRequestModel authorization)
        {
            User? FindUser = _context.Users.SingleOrDefault(user => user.Username == authorization.username);

            if (FindUser == null)
            {
                return await Task.FromResult<LoginResponse>(null);
            }

            string tokenCreated = generateToken(authorization.username);

            return new LoginResponse() { Token = tokenCreated, Result = true, Msg = "token created!"};
        }
    }
}
