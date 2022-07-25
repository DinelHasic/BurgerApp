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
        Task<IReadOnlyList<OrderInfoViewModel>> GetAllOrders();

        Task AddNewOrder(OrderViewModel order);

        Task<OrderInfoViewModel> GetOrderDetailById(int id);

        Task<OrderViewModel> GetOrderById(int id);

        Task UpdateOrder(int id, OrderInfoViewModel updateOrder);

        Task DeleteOrder(OrderViewModel order);

        Task<IEnumerable<OrderInfoViewModel>> SortByIdOrder(string searchUserId);
    }
}
