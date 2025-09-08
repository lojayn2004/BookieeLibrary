

using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistance.AppData;

namespace Presistance.Repositories
{
    internal class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ApplicationDbContext _appDbContext;

        public GenericRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

     
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool AsNoTracking = true)
        {
            if(AsNoTracking)
                return await _appDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            return await _appDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey key)
        {
            return await _appDbContext.Set<TEntity>().FindAsync(key);
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);

        }

        public void Add(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Add(entity);

        }

        public void Delete(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity?> GetByIdAsync(Specification<TEntity> specification)
        {
            var query =  SpecificationEvaluator.CreateQuery(_appDbContext.Set<TEntity>(), specification);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Specification<TEntity> specification)
        {
            var query = SpecificationEvaluator.CreateQuery(_appDbContext.Set<TEntity>(), specification);
            return await query.ToListAsync();
        }
    }

}
