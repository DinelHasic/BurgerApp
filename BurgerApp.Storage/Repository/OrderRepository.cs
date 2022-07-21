using BurgerApp.Domain.Enteties;
using BurgerApp.Domain.Repository;
using BurgerApp.Storage.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Storage.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrderById(int id)
        {
            Order order = BurgerDatabase.Orders.FirstOrDefault(o => o.Id == id);

            BurgerDatabase.Orders.Remove(order);
        }

        public Order FindOrderById(int orderId)
        {
            return BurgerDatabase.Orders.FirstOrDefault(o => o.Id == orderId);
        }

        public int GenerateOrderId()
        {
            if (BurgerDatabase.Orders.Count == 0)
            {
                return 1;
            }

            return BurgerDatabase.Orders.Max(x => x.Id) + 1;
        }

        public IReadOnlyList<Order> GetAllOrder()
        {
            return BurgerDatabase.Orders;
        }

        public void Insert(Order order)
        {
           BurgerDatabase.Orders.Add(order);
        }

        public IReadOnlyList<Order> OrderOrdersById(int id)
        {
           return BurgerDatabase.Orders.Where(x => x.User.Id == id).ToArray();
        }
    }
}
