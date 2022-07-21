using BurgerApp.Contracts.ViewModels.Burger;
using BurgerApp.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Mapper
{
    public static class BurgerMapper
    {
        public static BurgerListViewModel BurgerManue(this Burger burger)
        {
            return new BurgerListViewModel
            {
                BurgerId = burger.Id,
                BurgerName = burger.Name,
                BurgerURL = burger.ImageURL,

            };
        }

        public static BurgerManueListViewModel BurgersManueList(this List<Burger> burgers)
        {
            return new BurgerManueListViewModel
            {
                BurgerList = burgers.Select(x => x.BurgerManue()).ToList(),
            };
        }

        public static BurgerInfoViewModel ToBurgerInfoView(this Burger burger)
        {
            return new BurgerInfoViewModel
            {
                BurgerId = burger.Id,
                BurgerName = burger.Name,
                BurgerPrice = burger.Price,
                BurgerURL = burger.ImageURL,
                BurgerHasFries = burger.HasFries,
                BurgerIsVegan = burger.IsVegan,
                BurgerIsVegetarian = burger.IsVegetarian,
            };
        }
    }
}
