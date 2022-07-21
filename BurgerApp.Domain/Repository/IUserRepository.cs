using BurgerApp.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Repository
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        IReadOnlyList<User> GetUsers();
    }
}
