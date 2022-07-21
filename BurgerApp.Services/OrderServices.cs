using BurgerApp.Contracts;
using BurgerApp.Contracts.ViewModels.Order;
using BurgerApp.Domain.Enteties;
using BurgerApp.Domain.Repository;
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
        public OrderServices(IOrderRepository orderRepository,IBurgerRepository burgerRepository,IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _bragerRepository = burgerRepository;
            _userRepository = userRepository;  
        }

        public async Task AddNewOrder(OrderViewModel order)
        {
            Order newOrder = new Order();

            int Id = _orderRepository.GenerateOrderId();

            List<Burger> burgers =  await _bragerRepository.GetBurgersByIdAsync(order.BurgersId);

            User user = _userRepository.GetUserById(order.UserId);

            newOrder.Id = Id;

            newOrder.Burgers = burgers;

            newOrder.User = user;

            _orderRepository.Insert(newOrder);
        }

        public void DeleteOrder(OrderViewModel order)
        {
            _orderRepository.DeleteOrderById(order.Id);
        }

        public IReadOnlyList<OrderInfoViewModel> GetAllOrders()
        {
            IReadOnlyList<Order> orders = _orderRepository.GetAllOrder();

            return orders.Select(x => x.ToOrderInfoViewModel()).ToArray();
        }

        public OrderInfoViewModel GetOrderDetailById(int id)
        {
            Order order = _orderRepository.FindOrderById(id);

            return  order.ToOrderInfoViewModel();
        }

        public OrderViewModel GetOrderById(int id)
        {
            Order order = _orderRepository.FindOrderById(id);

            return order.ToOrderViewModel();
        }


        public async Task UpdateOrder(int id, OrderInfoViewModel updateOrder)
        {
            Order order = _orderRepository.FindOrderById(id);

            List<Burger> burger = await _bragerRepository.GetBurgersByIdAsync(updateOrder.BurgersId);

            User user = _userRepository.GetUserById(updateOrder.UserId);

            order.OrderDate = updateOrder.DateOrder;
            order.User = user;
            order.Burgers = burger;
        }

        public IEnumerable<OrderInfoViewModel> SortByIdOrder(string searchUserId)
        {
            int.TryParse(searchUserId, out int id);

            IReadOnlyList<Order> orders = _orderRepository.OrderOrdersById(id);

            return orders.Select(x => x.ToOrderInfoViewModel()).ToArray();
        }
    }
}
