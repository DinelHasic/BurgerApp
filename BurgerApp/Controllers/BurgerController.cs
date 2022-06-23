using BurgerApp.Models.Domain;
using BurgerApp.Models.Mappers;
using BurgerApp.Models.ViewModel;
using BurgerApp.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
    [Route("burger")]
    public class BurgerController : Controller
    {

        [Route("manue")]
        public IActionResult Index()
        {
            BurgerManueViewModelList burgers = Database.Burgers.BurgersManueList();
            return View(burgers);
        }

        [Route("ditail")]
        public IActionResult Detail(string name)
        {
            Burger burger = Database.Burgers.FirstOrDefault(x => x.Name == name);

            if (burger == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(burger);
        }
    }
}
