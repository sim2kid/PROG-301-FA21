using Microsoft.AspNetCore.Mvc;
using CoffeeMachine;
using MVC_Site.ViewModels;
using System;

namespace MVC_Site.Controllers
{
    public class CafeController : Controller
    {
        CoffeeView cafe;


        public CafeController() 
        {
            cafe = Toolbox.Instance.coffeeView;
        }

        public IActionResult Index(string Action, string size, string sugar, string cream)
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

            if (!string.IsNullOrWhiteSpace(size)) 
            {
                if (string.IsNullOrWhiteSpace(sugar))
                    sugar = "0";
                if (string.IsNullOrWhiteSpace(cream)) 
                    cream = "0";
                float si = StringToInt(size);
                int su = StringToInt(sugar);
                int cr = StringToInt(cream);
                cafe.BrewCoffee(si, cr, su);
            }

            return View(cafe);
        }
        public IActionResult Brew() 
        {
            return View(cafe);
        }
        public IActionResult History() 
        {
            return View(cafe);
        }

        public static int StringToInt(string str)
        {
            try
            {
                return Int32.Parse(str);
            }
            catch
            {
                return 0;
            }
        }
    }
}
