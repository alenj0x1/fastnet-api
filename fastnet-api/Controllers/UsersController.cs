using fastnet_api.Bll;
using fastnet_api.DBModels;
using fastnet_api.Helper;
using fastnet_api.Models.Users;
using fastnet_api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fastnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authorizationService;

        public UsersController(IAuthService authenticationService)
        {
            _authorizationService = authenticationService;
        }

        UserBll UserB = new();
        CashBll CashB = new();

        // Get all users
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return UserB.GetUsers();
        }

        // Get user by ID
        [HttpGet]
        [Route("{id}")]
        public ActionResult<User?> GetUserById(int id)
        {
            User? FindUser = UserB.GetUser(id);

            if (FindUser == null)
            {
                return NotFound();
            }

            return Ok(FindUser);
        }

        // Assign cash
        [Authorize]
        [HttpPost]
        [Route("assignCash")]
        public ActionResult<Cash?> AssignCash([FromBody] AssignCashRequestModel model)
        {
            User? UserRequest = new ManageToken(HttpContext, _authorizationService).GetUser();
     
            User? FindUser = UserB.GetUser(model.userId);

            // Not manager
            if (UserRequest.RolRolid != 1)
            {
                return Unauthorized("you are not a manager");
            }

            // User id invalid
            if (FindUser == null) {
                Console.WriteLine("user id invalid");
                return BadRequest("user id invalid");
            }

            List<User> FindCashiers = UserB.GetUsers().Where(x => x.RolRolid == 2).ToList();

            // Without cashiers
            if (FindCashiers.Count == 0) {
                Console.Write("without cashiers");
                return NotFound("without cashiers");
            }

            // Same user
            if (FindUser.Userid == UserRequest.Userid)
            {
                Console.Write("same user");
                return BadRequest("you cannot assign yourself a cash");
            }

            Cash? newAssignedCash = CashB.AssignCash(model);

            if (newAssignedCash == null)
            {
                return BadRequest("invalid cash or without cash created. Create one");
            }

            return Ok(newAssignedCash);
        }

        // Create cashier
        [Authorize]
        [HttpPost]
        [Route("createCashier")]
        public ActionResult<User> CreateCashier([FromBody] CreateCashierRequestModel request)
        {
            User? FindUser = UserB.GetUserByUsername(request.username);

            if (FindUser != null)
            {
                return BadRequest("user created");
            }

            User newUser = new()
            {
                Username = request.username,
                Email = request.email,
                Password = "pass"+request.username,
                RolRolid = 2
            };

            UserB.CreateUser(newUser);
           
            return Ok(newUser);
        }

        [Authorize]
        [HttpDelete]
        [Route("remove/{userId}")]
        public ActionResult<Boolean> RemoveCashier(int userId)
        {
            User? FindUser = UserB.GetUser(userId);

            if (FindUser  == null)
            {
                return NotFound("invalid user id");
            }

            CashB.RemoveAssignedCash(userId);
            UserB.RemoveUser(FindUser);

            return Ok("user removed");
        }
    }
}
