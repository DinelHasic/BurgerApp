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
        Task<User> GetUserById(int id);

        Task<IReadOnlyList<User>> GetUsers();
        void AddUser(User user);
        Task<int> GenerateUserId();
    }
}
