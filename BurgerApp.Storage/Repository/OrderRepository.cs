using BurgerApp.Domain.Enteties;
using BurgerApp.Domain.Repository;
using BurgerApp.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Storage.Repository
{

    public class OrderRepository :  ReposiotyBase<Order>,IOrderRepository
    {
        public OrderRepository(IBurgerDbContext burgerDbContext) : base(burgerDbContext)
        {

        }

        public async Task DeleteOrderById(int id)
        {
            Order order = await GetById(id).SingleOrDefaultAsync();
            RemoveEntity(order);
        }

        public async Task<Order> FindOrderById(int orderId)
        {
            return await GetById(orderId).Include(x => x.Burgers).SingleOrDefaultAsync();
        }

        public int GenerateOrderId()
        {
            if (GetAll().Count() == 0)
            {
                return 1;
            }

            return  GetAll().Max(x => x.Id) + 1;
        }

        public async Task<IReadOnlyList<Order>> GetAllOrder()
        {
            return await GetAll().Include(x => x.Burgers).Include(x => x.User).ToArrayAsync();
        }

        public void Insert(Order order)
        {
            InsterEntity(order);
        }

        public async Task<IReadOnlyList<Order>> OrderOrdersById(int id)
        {
           return await GetAll().Include(x => x.User).Include(x => x.Burgers).Where(x => x.User.Id == id).ToArrayAsync();
        }
    }
}
