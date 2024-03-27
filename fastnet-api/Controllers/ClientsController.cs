using fastnet_api.Bll;
using fastnet_api.DBModels;
using fastnet_api.Helper;
using fastnet_api.Models.Clients;
using fastnet_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fastnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IAuthService _authorizationService;

        public ClientsController(IAuthService authenticationService)
        {
            _authorizationService = authenticationService;
        }

        ClientsBll ClientB = new();

        [Authorize]
        [HttpGet]
        public ActionResult<List<Client>> GetClients()
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            if (UserRequest.RolRolid != 1)
            {
                return Unauthorized("you are not a manager");
            }

            return ClientB.GetClients();
        }

        [HttpGet]
        [Route("{clientId}")]
        public ActionResult<Client?> GetClientById(int clientId)
        {
            Client? FindClient = ClientB.GetClientById(clientId);

            if (FindClient == null)
            {
                return NotFound("client id invalid");
            }

            return Ok(FindClient);
        }

        [HttpGet]
        [Route("getByClientIdentification/{clientIdentification}")]
        public ActionResult<Client?> GetClientByIdentification(string clientIdentification) 
        {
            Client? FindClient = ClientB.GetClientByIdentification(clientIdentification);

            if (FindClient == null)
            {
                return NotFound("identification invalid");
            }

            return Ok(FindClient);
        }

        [Authorize]
        [HttpPost]
        [Route("new")]
        public ActionResult<Client?> NewClient([FromBody] NewClientRequestModel model)
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            if (UserRequest.RolRolid != 2)
            {
                return Unauthorized("you are not a cashier");
            }

            Client? ClientNew = ClientB.NewClient(model);

            if (ClientNew == null)
            {
                return BadRequest("client registered");
            }

            return ClientNew;
        }

        [Authorize]
        [HttpPut]
        [Route("update/{clientId}")]
        public ActionResult<Client?> UpdateClient(int clientId, UpdateClientRequestModel model)
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            if (UserRequest.RolRolid != 2)
            {
                return Unauthorized("you are not cashier");
            }

            Client? ClientUpdate = ClientB.UpdateClient(clientId, model);

            if (ClientUpdate == null)
            {
                return NotFound("id invalid");
            }

            return Ok(ClientUpdate);
        }

        [Authorize]
        [HttpDelete]
        [Route("remove/{clientId}")]
        public ActionResult<Client?> RemoveClient(int clientId)
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            if (UserRequest.RolRolid != 2)
            {
                return Unauthorized("you are not cashier");
            }

            Client? ClientRemove = ClientB.RemoveClient(clientId);

            if (ClientRemove == null)
            {
                return NotFound("id invalid");
            }

            return Ok(ClientRemove);
        }
    }
}
