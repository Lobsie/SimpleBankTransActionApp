using Microsoft.EntityFrameworkCore;
using SimpleBankTansactionApp.Infrastructure.Data;
using SimpleBankTransactionApp.Core.Entities.Base;
using SimpleBankTransactionApp.Core.Interfaces.Repositories;

namespace SimpleBankTansactionApp.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : EntityBase
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(Id);

            return entity;
        }

        public IQueryable<TEntity> GetAllAsync()
        {
            var entities = _dbContext.Set<TEntity>().AsNoTracking();

            return entities;
        }

        public async Task<IEnumerable<TEntity>> ListAllAsync()
        {
            var entities = await GetAllAsync().ToListAsync();

            return entities;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();
            
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }
    }
}