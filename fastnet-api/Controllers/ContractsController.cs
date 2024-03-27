using fastnet_api.Bll;
using fastnet_api.DBModels;
using fastnet_api.Helper;
using fastnet_api.Models.Contract;
using fastnet_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fastnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IAuthService _authorizationService;

        public ContractsController(IAuthService authenticationService)
        {
            _authorizationService = authenticationService;
        }

        ContractBll ContractB = new();

        [Authorize]
        [HttpPost]
        [Route("new")]
        public ActionResult<Contract?> NewContract([FromBody] NewContractRequestModel model)
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            if (UserRequest.RolRolid != 2)
            {
                return BadRequest("you are not cashier");
            }

            Contract? ContractNew = ContractB.NewContract(model);

            return ContractNew;
        }
    }
}
