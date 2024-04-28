using WebReactApp.Server.Core;
using WebReactApp.Server.Models;
using WebReactApp.Server.Repositories.IRepositories;

namespace WebReactApp.Server.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext db) : base(db)
        {
        }
    }
}
