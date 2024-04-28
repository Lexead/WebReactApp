using System.Linq.Expressions;

namespace WebReactApp.Server.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T?> Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }
}
