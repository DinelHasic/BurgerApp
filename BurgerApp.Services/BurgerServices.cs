using BurgerApp.Contracts;
using BurgerApp.Contracts.ViewModels.Burger;
using BurgerApp.Domain.Enteties;
using BurgerApp.Domain.Repository;
using BurgerApp.Domain.UnitOfWork;
using BurgerApp.Services.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerApp.Services
{
    public class BurgerServices : IBurgerServices
    {

        private readonly IBurgerRepository _burgerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public BurgerServices(IBurgerRepository burgerRepository, IUnitOfWork unitOfWork)
        {
            _burgerRepository = burgerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<BurgerListViewModel>> GetAllBurgersAsync()
        {
            IReadOnlyList<Burger> burgers = await _burgerRepository.GetAllBurgersAsync();

            return burgers.Select(x => x.BurgerManue()).ToArray();
        }


        public async Task AddBurgerAsync(BurgerInfoViewModel newBurger)
        {
            int burgerId = _burgerRepository.GenerateBurgerId();


            Burger burger = new Burger(newBurger.BurgerName, newBurger.BurgerPrice, newBurger.BurgerIsVegetarian, newBurger.BurgerIsVegan, newBurger.BurgerHasFries, newBurger.BurgerURL);

            _burgerRepository.Insert(burger);

            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<BurgerInfoViewModel> GetBurgerByIdAsync(int burgerId)
        {
            Burger burer = await _burgerRepository.FindBurgerByIdAsync(burgerId);

            return burer.ToBurgerInfoView();
        }

        public async Task RemoveBurgerByIdAsync(int id)
        {
           await _burgerRepository.DeleteBurgerByIdAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateBurgerAsync(int id, BurgerInfoViewModel burgerInfo)
        {
            Burger burger = await _burgerRepository.FindBurgerByIdAsync(id);

            burger.IsVegetarian = burgerInfo.BurgerIsVegetarian;
            burger.IsVegan = burgerInfo.BurgerIsVegan;
            burger.Name = burgerInfo.BurgerName;
            burger.Price = burgerInfo.BurgerPrice;
            burger.HasFries = burgerInfo.BurgerHasFries;
            burger.ImageURL = burgerInfo.BurgerURL;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
