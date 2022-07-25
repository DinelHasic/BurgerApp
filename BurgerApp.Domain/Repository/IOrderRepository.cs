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
        Task<IReadOnlyList<Order>> GetAllOrder();

        Task<Order> FindOrderById(int orderId);

        Task DeleteOrderById(int id);

        int GenerateOrderId();

        void Insert(Order order);

        Task<IReadOnlyList<Order>> OrderOrdersById(int id);
    }
}
