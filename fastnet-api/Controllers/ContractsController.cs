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

            if (ContractNew == null)
            {
                return NotFound("client has contract active");
            }

            return Ok(ContractNew);
        }

        [HttpGet]
        [Route("{contractId}")]
        public ActionResult<Contract?> GetContractById(int contractId)
        {
            Contract? FindContract = ContractB.GetContractById(contractId);

            if (FindContract == null)
            {
                return NotFound("contract id invalid");
            }

            return Ok(FindContract);
        }

        [HttpGet]
        [Route("getContractByClientId/{clientId}")]
        public ActionResult<Contract?> GetContractByClientId(int clientId)
        {
            Contract? FindContract = ContractB.GetContractByClientId(clientId);

            if (FindContract == null)
            {
                return NotFound("client id invalid or not exist");
            }

            return Ok(FindContract);
        }

        [Authorize]
        [HttpPut]
        [Route("update")]
        public ActionResult<Contract?> UpdateContract([FromBody] UpdateContractRequestModel model)
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            if (UserRequest.RolRolid != 2)
            {
                return BadRequest("you are not cashier");
            }

            Contract? ContractUpdate = ContractB.UpdateContract(model);

            if (ContractUpdate == null)
            {
                return NotFound("client id invalid, service id invalid or contract ended");
            }

            return Ok(ContractUpdate);
        }

        [Authorize]
        [HttpPut]
        [Route("end/{clientId}")]
        public ActionResult<Contract?> EndContract(int clientId)
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            if (UserRequest.RolRolid != 2)
            {
                return BadRequest("you are not cashier");
            }

            Contract? ContractEnd = ContractB.EndContract(clientId);

            if (ContractEnd == null)
            {
                return NotFound("client id invalid");
            }

            return Ok(ContractEnd);
        }
    }
}
