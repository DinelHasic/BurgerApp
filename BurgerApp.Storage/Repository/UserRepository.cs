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
    public class UserRepository : IUserRepository
    {
        public User GetUserById(int id)
        {
            User user = BurgerDatabase.Users.SingleOrDefault(x => x.Id == id);

            return user;
        }

        public IReadOnlyList<User> GetUsers()
        {
            return BurgerDatabase.Users.ToArray();
        }
    }
}
