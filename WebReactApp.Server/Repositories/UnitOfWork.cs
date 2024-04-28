using WebReactApp.Server.Core;
using WebReactApp.Server.Repositories.IRepositories;

namespace WebReactApp.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected AppDbContext db;
        public IOrderRepository OrderRepository { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            this.db = db;
            OrderRepository = new OrderRepository(db);
        }

        public async Task<int> Save()
        {
            return await db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
