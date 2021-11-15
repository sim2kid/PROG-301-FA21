using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoffeeMachine;
using System.Collections.Generic;

namespace MVC_Site.Controllers
{
    public class CoffeeMachineController : Controller
    {
        List<DrinkMachine> Machines;

        public CoffeeMachineController() 
        {
            Machines = new List<DrinkMachine>();
            Machines.Add(new DrinkMachine());
        }

        // GET: CoffeeMachine
        public ActionResult Index()
        {
            return View(Machines);
        }

        // GET: CoffeeMachine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CoffeeMachine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeeMachine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoffeeMachine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CoffeeMachine/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoffeeMachine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CoffeeMachine/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
