using Microsoft.AspNetCore.Mvc;

namespace MVC_Site.Controllers
{
    public class CafeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
