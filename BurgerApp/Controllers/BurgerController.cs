using BurgerApp.Models.Domain;
using BurgerApp.Models.Mappers;
using BurgerApp.Models.ViewModel;
using BurgerApp.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{

    public class BurgerController : Controller
    {

        public IActionResult Index()
        {
            BurgerManueViewModelList burgers = Database.Burgers.BurgersManueList();
            return View(burgers);
        }


        public IActionResult Detail(int id)
        {
            BurgerViewModel burger = Database.Burgers.FirstOrDefault(x => x.Id == id)?.BurgerView();

            if (burger == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(burger);
        }

        public IActionResult Edit(int id)
        {
            BurgerViewModel burger = Database.Burgers.FirstOrDefault(x => x.Id == id).BurgerView();

            if (burger == null)
            {
                return NotFound();
            }

            return View(burger);
        }


        [HttpPost]
        public IActionResult Edit(int id, BurgerViewModel burgerInfo)
        {
            Burger burger = Database.Burgers.SingleOrDefault(x => x.Id == id);

            if (burger is null)
            {
                return NotFound();
            }

            burger.Update(burgerInfo);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            BurgerViewModel burger = Database.Burgers.SingleOrDefault(x => x.Id == id).BurgerView();

            if (burger is null)
            {
                return NotFound();
            }

            return View(burger);
        }

        [HttpPost]
        public IActionResult Delete(int id, BurgerViewModel burger)
        {
            Burger burgerToDelete = Database.Burgers.SingleOrDefault(x => x.Id == id);

            if (burger is null)
            {
                return NotFound();
            }


            Database.Burgers.Remove(burgerToDelete);

            return RedirectToAction("Index");
        }


        public IActionResult Create()
        {
            BurgerViewModel newBurger = new BurgerViewModel();

            return View(newBurger);
        }

        [HttpPost]
        public IActionResult Create(BurgerViewModel newBurger)
        {
            if (newBurger is null)
            {
                return NotFound();
            }

            Burger burger = new Burger();

            burger.Update(newBurger);
            burger.SetId(Database.GetNextBurgerId());
            Database.Burgers.Add(burger);

            return RedirectToAction("Index");
        }
    }
}

