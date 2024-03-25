using Microsoft.AspNetCore.Mvc;

namespace fastnet_api.Controllers
{
    public class CashController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
