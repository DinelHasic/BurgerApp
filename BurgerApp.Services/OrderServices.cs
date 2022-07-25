using BurgerApp.Contracts;
using BurgerApp.Contracts.ViewModels.Order;
using BurgerApp.Domain.Enteties;
using BurgerApp.Domain.Repository;
using BurgerApp.Domain.UnitOfWork;
using BurgerApp.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services
{
    public class OrderServices : IOrderServices
    {
        private IOrderRepository _orderRepository;
        private IBurgerRepository _bragerRepository;
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;
        public OrderServices(IOrderRepository orderRepository, IBurgerRepository burgerRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _bragerRepository = burgerRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewOrder(OrderViewModel order)
        {
            Order newOrder = new Order();


            List<Burger> burgers = await _bragerRepository.GetBurgersByIdAsync(order.BurgersId);

            User user = await _userRepository.GetUserById(order.UserId);

            newOrder.Burgers = burgers;

            newOrder.User = user;

            _orderRepository.Insert(newOrder);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteOrder(OrderViewModel order)
        {
            _orderRepository.DeleteOrderById(order.Id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<OrderInfoViewModel>> GetAllOrders()
        {
            IReadOnlyList<Order> orders = await _orderRepository.GetAllOrder();

            return orders.Select(x => x.ToOrderInfoViewModel()).ToArray();
        }

        public async Task<OrderInfoViewModel> GetOrderDetailById(int id)
        {
            Order order = await _orderRepository.FindOrderById(id);

            return order.ToOrderInfoViewModel();
        }

        public async Task<OrderViewModel> GetOrderById(int id)
        {
            Order order = await _orderRepository.FindOrderById(id);

            return order.ToOrderViewModel();
        }


        public async Task UpdateOrder(int id, OrderInfoViewModel updateOrder)
        {
            Order order = await  _orderRepository.FindOrderById(id);

            List<Burger> burgers = await _bragerRepository.GetBurgersByIdAsync(updateOrder.BurgersId);


            User user = await _userRepository.GetUserById(updateOrder.UserId);


            order.OrderDate = updateOrder.DateOrder;
            order.Burgers = burgers;
            order.User = user;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderInfoViewModel>> SortByIdOrder(string searchUserId)
        {
            int.TryParse(searchUserId, out int id);

            IReadOnlyList<Order> orders = await _orderRepository.OrderOrdersById(id);

            return orders.Select(x => x.ToOrderInfoViewModel()).ToArray();
        }
    }
}
