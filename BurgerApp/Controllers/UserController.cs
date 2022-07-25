using BurgerApp.Contracts;
using BurgerApp.Contracts.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
    public class UserController : Controller
    {
        private IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserDetailListViewModel> users = await _userServices.GetAllUsersDetail();

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserDetailListViewModel newUser)
        {
            if(newUser is null)
            {
                return NotFound();
            }

            _userServices.AddNewUser(newUser);

            return RedirectToAction("Create","Order");
        }
    }
}
