using System.Linq.Expressions;

namespace TheatreApp.Data.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> All();
        IQueryable<TEntity> AllAsNoTracking();
        Task AddAsync(TEntity item);
        Task AddRangeAsync(IEnumerable<TEntity> items);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> HardDeleteAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity item);
        Task SaveChangesAsync();
    }
}
