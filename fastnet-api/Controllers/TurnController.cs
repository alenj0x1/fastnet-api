using fastnet_api.Bll;
using fastnet_api.DBModels;
using fastnet_api.Helper;
using fastnet_api.Repository;
using fastnet_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fastnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        private readonly IAuthService _authorizationService;

        public TurnController(IAuthService authenticationService)
        {
            _authorizationService = authenticationService;
        }

        CashBll CashB = new();
        TurnBll TurnB = new();

        [Authorize]
        [HttpGet]
        public ActionResult<Turn?> GetCurrentTurn ()
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            if (UserRequest.RolRolid != 2)
            {
                return BadRequest("you are not cashier.");
            }

            Turn? FindTurn = TurnB.GetCurrentTurn(UserRequest.Userid);

            if (FindTurn == null)
            {
                return NotFound("you have not taken a turn.");
            }

            return Ok(FindTurn);
        }

        [Authorize]
        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Turn>> GetAllTurns()
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();
            Cash? FindCashierCash = CashB.GetCashByCashierId(UserRequest.Userid);

            if (UserRequest.RolRolid != 2)
            {
                return BadRequest("you are not cashier.");
            }

            if (FindCashierCash == null)
            {
                return BadRequest("you don't have an assigned cash. Contact with manager");
            }

            List<Turn> FindTurns = TurnB.GetAllTurns(UserRequest.Userid);

            return Ok(FindTurns);
        }

        [Authorize]
        [HttpGet]
        [Route("getTurnsByCashId/{cashId}")]
        public ActionResult<List<Turn>> GetTurnsByCashId(int cashId)
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            Cash? FindCash = CashB.GetCashById(cashId);

            if (UserRequest.RolRolid != 1)
            {
                return BadRequest("you are not manager. Contact with manager");
            }

            if (FindCash == null)
            {
                return NotFound("cash not exist.");
            }

            if (FindCash.Active == false)
            {
                return NotFound("this cash not is active. Activate now.");
            }

            List<Turn> FindTurns = TurnB.GetTurnsByCashId(cashId);

            return Ok(FindTurns);
        }

        [Authorize]
        [HttpGet]
        [Route("takeTurn/{turnId}")]
        public ActionResult<Attention?> TakeTurn(int turnId)
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            if (UserRequest.RolRolid != 2)
            {
                return BadRequest("you are not cashier. Contact with manager");
            }

            Attention? TryTakeTurn = TurnB.TakeTurn(turnId, UserRequest.Userid);

            if (TryTakeTurn == null)
            {
                return NotFound("turn invalid");
            }

            return Ok(TryTakeTurn);
        }

        [Authorize]
        [HttpGet]
        [Route("nextTurn")]
        public ActionResult<Turn?> NextTurn(int turnId)
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();

            if (UserRequest.RolRolid != 2)
            {
                return BadRequest("you are not cashier. Contact with manager");
            }

            Turn? TryNextTurn = TurnB.NextTurn(UserRequest.Userid);

            if (TryNextTurn == null)
            {
                return NotFound("not have a turn taked.");
            }

            return TryNextTurn;
        }
    }
}
