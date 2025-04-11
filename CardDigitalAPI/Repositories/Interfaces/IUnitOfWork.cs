namespace CardDigitalAPI.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        //Instancia dos repositorios
        IClientRepository ClientRepository { get; }
        IBuyerRepository BuyerRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IBoletoRepository BoletoRepository { get; }
        Task CommitAsync();
    }
}
