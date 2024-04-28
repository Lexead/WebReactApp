using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebReactApp.Server.Core;
using WebReactApp.Server.Repositories.IRepositories;

namespace WebReactApp.Server.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext db;
        protected DbSet<T> dbSet;

        public Repository(AppDbContext db)
        {
            this.db = db;
            dbSet = this.db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public async Task<T?> Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;

            includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            query = query.Where(filter);

            return await query.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;

            includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            dbSet.UpdateRange(entities);
        }
    }
}
