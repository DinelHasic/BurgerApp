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
    public class UserRepository : ReposiotyBase<User>, IUserRepository
    {
        public UserRepository(IBurgerDbContext burgerDbContext) : base(burgerDbContext)
        {
        }

        public void AddUser(User user)
        {
            InsterEntity(user);
        }

        public async Task<int> GenerateUserId()
        {
           if(GetAll().Count() == 0)
            {
                return 0;
            }
          
           return await GetAll().MaxAsync(x => x.Id) + 1;
        }

        public async Task<User> GetUserById(int id)
        {
            User user =  await GetById(id).SingleOrDefaultAsync();

            return user;
        }

        public async Task<IReadOnlyList<User>> GetUsers()
        {
            return  await GetAll().ToArrayAsync();
        }
    }
}
