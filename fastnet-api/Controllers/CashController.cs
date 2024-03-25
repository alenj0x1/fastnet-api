using fastnet_api.Bll;
using fastnet_api.DBModels;
using fastnet_api.Models.Cash;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fastnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        CashBll CashB = new();
        UserBll UserB = new();

        [HttpGet]
        public ActionResult<List<Cash>> GetCashes()
        {
            return Ok(CashB.GetCashes());
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public ActionResult<Cash> CreateCash([FromBody] CreateCashRequestModel model)
        {
            return Ok(CashB.CreateCash(model));
        }

        [Authorize]
        [HttpDelete]
        [Route("remove/{cashId}")]
        public ActionResult<bool> RemoveCash(int cashId)
        {
            bool RemoveCashR = CashB.RemoveCash(cashId);
            if (RemoveCashR == false) {
                return BadRequest(RemoveCashR);
            }

            return Ok(RemoveCashR);
        }

        [Authorize]
        [HttpGet]
        [Route("{cashId}")]
        public ActionResult<Cash?> GetCash(int cashId)
        {
            Cash? FindCash = CashB.GetCashById(cashId);

            if (FindCash == null)
            {
                return NotFound("invalid cash id");
            }

            return Ok(FindCash);
        }

        [Authorize]
        [HttpGet]
        [Route("getByCashierId/{cashierId}")]
        public ActionResult<Cash?> GetCashByCashierId(int cashierId)
        {
            User? FindUser = UserB.GetUser(cashierId);

            if (FindUser == null)
            {
                return NotFound("user not exist. Create one");
            }

            if (FindUser.RolRolid != 2)
            {
                return NotFound("Not is a cashier. Create one");
            }

            Cash? FindCash = CashB.GetCashByCashierId(cashierId);

            if (FindCash == null)
            {
                return NotFound("without cash");
            }

            return Ok(FindCash);
        }
    }
}
