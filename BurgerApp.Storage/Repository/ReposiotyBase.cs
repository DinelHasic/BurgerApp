using BurgerApp.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Storage.Repository
{
    public abstract class ReposiotyBase<T> where T : BaseEntity
    {
        protected readonly IBurgerDbContext _burgerDbContext;
        
        protected ReposiotyBase(IBurgerDbContext burgerDbContext)
        {
            _burgerDbContext = burgerDbContext;
        }

        protected IQueryable<T> GetById(int id)
        {
            return _burgerDbContext.Set<T>().Where(x => x.Id == id);
        }

        protected IQueryable<T> GetAll()
        {
            return _burgerDbContext.Set<T>();
        }

        protected void InsterEntity(T item)
        {
            _burgerDbContext.Set<T>().Add(item);
        }

        protected void RemoveEntity(T item)
        {
            _burgerDbContext.Set<T>().Remove(item);
        }
    }
    
}
