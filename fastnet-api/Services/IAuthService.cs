using fastnet_api.Models.Authentication;

namespace fastnet_api.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> ReturnToken(LoginRequestModel authorization);
    }
}
