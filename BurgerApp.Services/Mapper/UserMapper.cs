using BurgerApp.Contracts.ViewModels.User;
using BurgerApp.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Mapper
{
    public static class UserMapper
    {
        public static UserInfoViewModel ToUserViewModel(this User user)
        {
            return new UserInfoViewModel
            {
               UserFullName = user.FirstName + " " + user.LastName,
               UserId = user.Id,
            };
        }

    }
}
