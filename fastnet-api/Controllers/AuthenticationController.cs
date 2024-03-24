using fastnet_api.Bll;
using fastnet_api.DBModels;
using fastnet_api.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fastnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private AuthenticationBll AuthenticationB;
        private readonly FastnetdbContext _db;

        public AuthenticationController(FastnetdbContext dbFastnetContext)
        {
            _db = dbFastnetContext;
            AuthenticationB = new AuthenticationBll(dbFastnetContext);
        }

        // POST api/<ValuesController>
        [HttpPost("/login")]
        public IActionResult Post([FromBody] LoginRequestModel value)
        {
            User? LoginUser = AuthenticationB.LoginUser(value);

            if (LoginUser == null)
            {
                return BadRequest("User or password incorrect.");
            }

            return Ok(LoginUser);
        }
    }
}
