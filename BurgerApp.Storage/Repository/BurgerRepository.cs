
using BurgerApp.Domain.Enteties;
using BurgerApp.Domain.Repository;
using BurgerApp.Storage.Database;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.Storage.Repository
{
    public class BurgerRepository : ReposiotyBase<Burger>,IBurgerRepository
    {
        public BurgerRepository(IBurgerDbContext burgerDbContext) : base(burgerDbContext)
        {

        }

        public async Task<IReadOnlyList<Burger>> GetAllBurgersAsync()
        {
            return await GetAll().ToArrayAsync();
        }

        public async Task<Burger> FindBurgerByIdAsync(int burgerId)
        {
            return await GetById(burgerId).SingleOrDefaultAsync();
        }

        public async Task DeleteBurgerByIdAsync(int id)
        {
           Burger burger = await GetById(id).SingleOrDefaultAsync();

           RemoveEntity(burger);
        }

        public int GenerateBurgerId()
        {
           if(GetAll().Count() == 0)
            {
                return 1;
            }

           return GetAll().Max(x => x.Id) + 1; 
        }

        public void Insert(Burger burger)
        {
            InsterEntity(burger);
        }

        public async Task<List<Burger>> GetBurgersByIdAsync(List<int> burgersId)
        {
            return await  GetAll().Where(x => burgersId.Contains(x.Id)).ToListAsync();
        }
    }
}
