using BurgerApp.Models.Domain;
using BurgerApp.Models.ViewModel;

namespace BurgerApp.Models.Mappers
{
    public static class BurgerMapper
    {
        private static BurgerMenuViewModel BurgerManue(this Burger burger)
        {
            return new BurgerMenuViewModel
            {
                BurgerId = burger.Id,
                BurgerName = burger.Name,
                BurgerURL = burger.ImageURL,

            };
        }

        public static BurgerManueViewModelList BurgersManueList(this List<Burger> burgers)
        {
            return new BurgerManueViewModelList
            {
                Burgers = burgers.Select(x => x.BurgerManue()).ToList(),
            };
        }

        public static BurgerViewModel BurgerView(this Burger burger)
        {
            return new BurgerViewModel
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
