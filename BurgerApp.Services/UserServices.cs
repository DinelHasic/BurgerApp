using BurgerApp.Contracts;
using BurgerApp.Contracts.ViewModels.User;
using BurgerApp.Domain.Enteties;
using BurgerApp.Domain.Repository;
using BurgerApp.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IReadOnlyList<UserInfoViewModel> GetAllUsers()
        {
            IReadOnlyList<User> users = _userRepository.GetUsers();

            return users.Select(x => x.ToUserViewModel()).ToList();
        }
    }
}
