using BurgerApp.Contracts;
using BurgerApp.Contracts.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
    public class OrderController : Controller
    {
        private IOrderServices _orderServices;
        private IBurgerServices _burgerServices;
        private IUserServices _userServices;

        public OrderController(IOrderServices orderServices,IBurgerServices burgerServices,IUserServices userServices)
        {
            _orderServices = orderServices;
            _burgerServices = burgerServices;
            _userServices = userServices;
        }

        public async Task<IActionResult> Index(string SearchUserId)
        {
            IEnumerable<OrderInfoViewModel> orders;

            if (string.IsNullOrEmpty(SearchUserId))
            {
                 orders = await _orderServices.GetAllOrders();
            }
            else
            {
                 orders = await _orderServices.SortByIdOrder(SearchUserId);
            }

            return View(orders);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Burgers = await _burgerServices.GetAllBurgersAsync();

            ViewBag.Users =  await _userServices.GetAllUsers();

            OrderInfoViewModel orders =  await _orderServices.GetOrderDetailById(id);

            return View(orders);
        }

        [HttpPost]
        public IActionResult Edit(int id, OrderInfoViewModel order)
        {
            if(order is null)
            {
                return NotFound();
            }

            _orderServices.UpdateOrder(id, order);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();

            ViewBag.Burgers = await _burgerServices.GetAllBurgersAsync();

            ViewBag.Users =  await _userServices.GetAllUsers();

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel order)
        {
            if(order is null)
            {
                return NotFound();
            }

            await _orderServices.AddNewOrder(order);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            OrderViewModel order = await _orderServices.GetOrderById(id);

            return View(order);
        }

        [HttpPost]
        public IActionResult Delete(OrderViewModel order)
        {
            if(order is null)
            {
                return NotFound();
            }
            _orderServices.DeleteOrder(order);

            return RedirectToAction("Index");
        }

    }
}
