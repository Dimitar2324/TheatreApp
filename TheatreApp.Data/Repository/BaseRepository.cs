using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using TheatreApp.Data.Repository.Interfaces;

namespace TheatreApp.Data.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly TheatreAppDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        protected BaseRepository(TheatreAppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet;
        }

        public IQueryable<TEntity> AllAsNoTracking()
        {
            return this.dbSet.AsNoTracking();
        }

        public async Task AddAsync(TEntity item)
        {
            await this.dbSet.AddAsync(item);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> items)
        {
            await this.dbSet.AddRangeAsync(items);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            this.ExecuteSoftDelete(entity);
            return await this.UpdateAsync(entity);
        }

        public Task<bool> HardDeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> UpdateAsync(TEntity item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.dbSet.Entry(item).State = EntityState.Modified;
                await this.dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task SaveChangesAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private void ExecuteSoftDelete(TEntity entity)
        {
            PropertyInfo? propery = this.GetIsDeletedPropertyInfo(entity);
            if (propery == null)
            {
                throw new InvalidOperationException("Cannot perform soft delete on not soft deletable model!");
            }

            propery.SetValue(entity, true);
        }

        private PropertyInfo? GetIsDeletedPropertyInfo(TEntity entity)
        {
            return typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(pi => pi.Name == "IsDeleted" && pi.PropertyType == typeof(bool));
        }
    }
}
