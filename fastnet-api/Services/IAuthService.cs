using fastnet_api.Models.Authentication;
using System.IdentityModel.Tokens.Jwt;

namespace fastnet_api.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> ReturnToken(LoginRequestModel authorization);
        int ReadToken(string token);
    }
}
