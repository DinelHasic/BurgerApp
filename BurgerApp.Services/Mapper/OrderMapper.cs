using BurgerApp.Contracts.ViewModels.Order;
using BurgerApp.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Mapper
{
    public static class OrderMapper
    {
        public static OrderInfoViewModel ToOrderInfoViewModel(this Order order)
        {
            return new OrderInfoViewModel
            {
                OrderId = order.Id,
                UserId = order.User.Id,
                DateOrder = order.OrderDate,
                BurgersId = order.Burgers.Select(x => x.Id).ToList(),
                OrderPrice = order.TotalPrice()
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                UserId = order.UserFk,
                BurgersId = order.Burgers.Select(x => x.Id).ToList()
            };
        }
    }
}
