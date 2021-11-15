using Microsoft.AspNetCore.Mvc;
using CoffeeMachine;
using MVC_Site.ViewModels;

namespace MVC_Site.Controllers
{
    public class CafeController : Controller
    {
        CoffeeView cafe;


        public CafeController() 
        {
            cafe = Toolbox.Instance.coffeeView;
        }

        public IActionResult Index(string Action)
        {
            Action = Action.ToLower().Trim();
            switch (Action) 
            {
                default:
                    break;
                case "refillcoffee":
                    cafe.RefillMachine(float.MaxValue, 0, 0);
                    break;
                case "refillsugar":
                    cafe.RefillMachine(0, int.MaxValue, 0);
                    break;
                case "refillcream":
                    cafe.RefillMachine(0, 0, int.MaxValue);
                    break;
            }

            return View(cafe);
        }
    }
}
