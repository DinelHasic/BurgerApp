using BurgerApp.Contracts.ViewModels.Burger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Contracts
{
    public interface IBurgerServices
    {
        Task<IReadOnlyList<BurgerListViewModel>> GetAllBurgersAsync();

        Task<BurgerInfoViewModel> GetBurgerByIdAsync(int burgerId);

        Task RemoveBurgerByIdAsync(int id);

        Task UpdateBurgerAsync(int id, BurgerInfoViewModel burgerInfo);

        Task AddBurgerAsync(BurgerInfoViewModel newBurger);
    }
}
