using Microsoft.EntityFrameworkCore;
using Supermarket.Contrats.Interfaces.Repositories;
using System.Linq.Expressions;

namespace Supermarket.Infraestrutura.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly SupermarketDbContext _supermarketDb;

        public BaseRepository(SupermarketDbContext supermarketDb)
        {
            _supermarketDb = supermarketDb;
        }

        public virtual IQueryable<T> GetAll() { var entitySet = _supermarketDb.Set<T>(); return entitySet.AsQueryable(); }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate) { return GetAll().FirstOrDefault(predicate)!; }

        public virtual Task<T> GetFirst(Expression<Func<T, bool>> predicate) { return GetAll().FirstOrDefaultAsync(predicate)!; }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) { return GetAll().Where(predicate); }

        public async Task Add(T entity)
        {
            var UpdatedAt = entity.GetType().GetProperty("UpdatedAt"); if (UpdatedAt != null) entity.GetType().GetProperty("UpdatedAt")?.SetValue(entity, DateTime.UtcNow);

            var CreatedAt = entity.GetType().GetProperty("CreatedAt"); if (CreatedAt != null) entity.GetType().GetProperty("CreatedAt")?.SetValue(entity, DateTime.UtcNow);

            await _supermarketDb.AddAsync(entity); _supermarketDb.Entry(entity).State = EntityState.Added; await _supermarketDb.SaveChangesAsync();
        }

        public async Task AddRange(List<T> entity) { _supermarketDb.AddRange(entity); await _supermarketDb.SaveChangesAsync(); }

        public async Task Delete(T entity) { _supermarketDb.Remove(entity); await _supermarketDb.SaveChangesAsync(); }

        public async Task DeleteRange(List<T> entity) { _supermarketDb.RemoveRange(entity); await _supermarketDb.SaveChangesAsync(); }

        public async Task Update(T entity)
        {
            var UpdatedAt = entity.GetType().GetProperty("UpdatedAt"); if (UpdatedAt != null) entity.GetType().GetProperty("UpdatedAt")?.SetValue(entity, DateTime.UtcNow);

            _supermarketDb.Update(entity); await _supermarketDb.SaveChangesAsync();
        }

        public async Task UpdateRange(List<T> entity) { _supermarketDb.UpdateRange(entity); await _supermarketDb.SaveChangesAsync(); }


    }
}
