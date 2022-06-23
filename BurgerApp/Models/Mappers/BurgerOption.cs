using BurgerApp.Models.Domain;
using BurgerApp.Models.ViewModel;

namespace BurgerApp.Models.Mappers
{
    public static class BurgerOption
    {

        private static BurgerMenuViewModel BurgerManue(this Burger burger)
        {
            return new BurgerMenuViewModel
            {
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
    }
}
