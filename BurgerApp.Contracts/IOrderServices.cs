using BurgerApp.Contracts.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Contracts
{
    public interface IOrderServices
    {
        IReadOnlyList<OrderInfoViewModel> GetAllOrders();

        Task AddNewOrder(OrderViewModel order);

        OrderInfoViewModel GetOrderDetailById(int id);

        OrderViewModel GetOrderById(int id);

        Task UpdateOrder(int id, OrderInfoViewModel updateOrder);

        void DeleteOrder(OrderViewModel order);

        IEnumerable<OrderInfoViewModel> SortByIdOrder(string searchUserId);
    }
}
