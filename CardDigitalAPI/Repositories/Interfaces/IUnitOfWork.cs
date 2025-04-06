namespace CardDigitalAPI.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        //Instancia dos repositorios
        IClientRepository ClientRepository { get; }
        IBuyerRepository BuyerRepository { get; }

        Task CommitAsync();
    }
}
