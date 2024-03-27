using fastnet_api.DBModels;
using fastnet_api.Repository;
using fastnet_api.Services;
using Microsoft.AspNetCore.Authentication;

namespace fastnet_api.Helper
{
    public class ManageToken
    {
        UserRepository UserRep = new();

        private string token = "";
        private readonly IAuthService _authorizationService;
        private FastnetdbContext ContextDB;

        public ManageToken(HttpContext httpContext, IAuthService authenticationService) {
            token = httpContext.Request.Headers["authorization"].ToString().Substring("Bearer ".Length).Trim(); ;
            ContextDB = new FastnetdbContext();
            _authorizationService = authenticationService;
        }

        public User? GetUser()
        {
            int userId = _authorizationService.ReadToken(token);

            if (userId < 0)
            {
                return null;
            }

            return UserRep.GetUserById(ContextDB, userId);
        }
    }
}
