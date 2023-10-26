using SimpleBankTransactionApp.Core.Entities.Base;

namespace SimpleBankTransactionApp.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : EntityBase
    {
        Task<TEntity> GetByIdAsync(Guid Id);
        IQueryable<TEntity> GetAllAsync();
        Task<IEnumerable<TEntity>> ListAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}