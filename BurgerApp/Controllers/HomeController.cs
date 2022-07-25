using BurgerApp.Contracts;
using BurgerApp.Contracts.ViewModels.Burger;
using BurgerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace BurgerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IBurgerServices _burgerService;

        public HomeController(ILogger<HomeController> logger,IBurgerServices burgerServices)
        {
            _logger = logger;
            _burgerService = burgerServices;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<BurgerListViewModel> burgers = await _burgerService.GetAllBurgersAsync();

            return View(burgers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}