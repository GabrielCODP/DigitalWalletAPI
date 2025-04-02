namespace CardDigitalAPI.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        //Instancia dos repositorios
        IClientRepository ClientRepository { get; }
        Task CommitAsync();
    }
}
