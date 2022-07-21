using BurgerApp.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Repository
{
    public interface IBurgerRepository
    {
        Task<IReadOnlyList<Burger>> GetAllBurgersAsync();

        Task<Burger> FindBurgerByIdAsync(int burgerId);

        Task DeleteBurgerByIdAsync(int id);

        int GenerateBurgerId();

        void Insert(Burger burger);

        Task<List<Burger>> GetBurgersByIdAsync(List<int> burgersId);
    }
}
