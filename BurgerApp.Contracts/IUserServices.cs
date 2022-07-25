
using BurgerApp.Contracts.ViewModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BurgerApp.Contracts
{
    public interface IUserServices
    {
        Task<IReadOnlyList<UserInfoViewModel>> GetAllUsers();

        Task<IReadOnlyList<UserDetailListViewModel>> GetAllUsersDetail();
        Task AddNewUser(UserDetailListViewModel newUser);
    }
}
