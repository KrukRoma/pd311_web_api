using Microsoft.AspNetCore.Mvc;

namespace pd311_web_api.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
