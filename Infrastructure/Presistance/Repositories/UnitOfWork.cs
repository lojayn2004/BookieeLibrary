

using Domain.Contracts;
using Presistance.AppData;
using System.Collections.Concurrent;

namespace Presistance.Repositories
{
    public class UnitOfWork(ApplicationDbContext _appDbConetxt) : IUnitOfWork
    {
        private ConcurrentDictionary<string, object> _repositories = new ConcurrentDictionary<string, object>();
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : class
        {
            string repoName = typeof(TEntity).Name;
            return (IGenericRepository <TEntity, Tkey>) _repositories.GetOrAdd(repoName, (_) => new GenericRepository<TEntity, Tkey>(_appDbConetxt));
           
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _appDbConetxt.SaveChangesAsync();
        }
    }
}
