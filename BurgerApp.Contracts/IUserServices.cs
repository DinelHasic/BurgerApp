
using BurgerApp.Contracts.ViewModels.User;
using System.Collections.Generic;

namespace BurgerApp.Contracts
{
    public interface IUserServices
    {
        IReadOnlyList<UserInfoViewModel> GetAllUsers();
    }
}
