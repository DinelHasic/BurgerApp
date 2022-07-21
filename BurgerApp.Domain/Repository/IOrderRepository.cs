using BurgerApp.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Repository
{
    public interface IOrderRepository
    {
        IReadOnlyList<Order> GetAllOrder();

        Order FindOrderById(int orderId);

        void DeleteOrderById(int id);

        int GenerateOrderId();

        void Insert(Order order);
        IReadOnlyList<Order> OrderOrdersById(int id);
    }
}
