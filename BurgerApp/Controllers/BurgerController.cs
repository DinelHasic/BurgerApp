
using BurgerApp.Contracts;
using BurgerApp.Contracts.ViewModels.Burger;
using BurgerApp.Models.Domain;
using BurgerApp.Models.Mappers;
using BurgerApp.Models.ViewModel;
using BurgerApp.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{

    public class BurgerController : Controller
    {
        private readonly IBurgerServices _burgerService;

        public BurgerController(IBurgerServices burgerService)
        {
            _burgerService = burgerService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<BurgerListViewModel>  burgers =  await _burgerService.GetAllBurgersAsync();

            return View(burgers);
        }


        public async Task<IActionResult> Detail(int id)
        {

            BurgerInfoViewModel burger = await _burgerService.GetBurgerByIdAsync(id);

            if (burger == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(burger);
        }

        public async Task<IActionResult> Edit(int id)
        {
            BurgerInfoViewModel burger = await _burgerService.GetBurgerByIdAsync(id);

            if (burger == null)
            {
                return NotFound();
            }
            return View(burger);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, BurgerInfoViewModel burgerInfo)
        {
            
            if (burgerInfo is null)
            {
                return NotFound();
            }

            await _burgerService.UpdateBurgerAsync(id, burgerInfo);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            BurgerInfoViewModel burger = await _burgerService.GetBurgerByIdAsync(id);

            if (burger is null)
            {
                return NotFound();
            }

            return View(burger);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, BurgerViewModel burger)
        {

            if (burger is null)
            {
                return NotFound();
            }

            await _burgerService.RemoveBurgerByIdAsync(id);

            return RedirectToAction("Index");
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BurgerInfoViewModel newBurger)
        {
            if (newBurger is null)
            {
                return NotFound();
            }


           await _burgerService.AddBurgerAsync(newBurger);

            return RedirectToAction("Index");
        }
    }
}

