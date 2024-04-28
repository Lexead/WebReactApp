namespace WebReactApp.Server.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }

        Task<int> Save();
    }
}
