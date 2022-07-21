using BurgerApp.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Storage.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IBurgerDbContext _dbContext;

        public UnitOfWork(IBurgerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges())
            {
                return await _dbContext.SaveChangesAsync();
            }

            return 0;
        }
    }
}
