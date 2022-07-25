using BurgerApp.Contracts;
using BurgerApp.Contracts.ViewModels.User;
using BurgerApp.Domain.Enteties;
using BurgerApp.Domain.Repository;
using BurgerApp.Domain.UnitOfWork;
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
        private IUnitOfWork _unitOfWork;
        public UserServices(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewUser(UserDetailListViewModel newUser)
        {

            User user = new User(newUser.UserFirstName, newUser.UserLastName, newUser.UserAdress, newUser.UserPhoneNumber);

           /* user.Id =  await _userRepository.GenerateUserId();*/

            _userRepository.AddUser(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<UserInfoViewModel>> GetAllUsers()
        {
            IReadOnlyList<User> users = await _userRepository.GetUsers();

            return users.Select(x => x.ToUserViewModel()).ToList();
        }

        public async Task<IReadOnlyList<UserDetailListViewModel>> GetAllUsersDetail()
        {
            IReadOnlyList<User> users = await _userRepository.GetUsers();

            return users.Select(x => x.ToUserDetailListViewModel()).ToList();
        }
    }
}
