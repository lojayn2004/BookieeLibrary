
namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(TKey key);

        Task<IEnumerable<TEntity>> GetAllAsync(bool AsNoTracking = true);

        Task<TEntity?> GetByIdAsync(Specification<TEntity> specification);

        Task<IEnumerable<TEntity>> GetAllAsync(Specification<TEntity> specification);

        void Update(TEntity entity);    

        void Delete(TEntity entity);

        void Add(TEntity entity);
        
    }
}
