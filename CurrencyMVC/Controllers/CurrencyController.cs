using Microsoft.AspNetCore.Mvc;

namespace CurrencyMVC.Controllers
{
    public class CurrencyController : Controller
    {
        static ChangeViewModel change = new ChangeViewModel();


        public IActionResult Index()
        {
            return View(change);
        }
    }
}
