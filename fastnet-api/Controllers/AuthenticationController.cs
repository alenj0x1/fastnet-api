using fastnet_api.Bll;
using fastnet_api.DBModels;
using fastnet_api.Models.Authentication;
using fastnet_api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fastnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authorizationService;

        public AuthenticationController(IAuthService authenticationService)
        {
            _authorizationService = authenticationService;
        }

        // POST api/<AuthentcationController>/login
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginRequestModel authorization)
        {
            var result = await _authorizationService.ReturnToken(authorization);

            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
