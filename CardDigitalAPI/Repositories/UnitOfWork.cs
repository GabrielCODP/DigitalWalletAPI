using CardDigitalAPI.Context;
using CardDigitalAPI.Repositories.Interfaces;

namespace CardDigitalAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IClientRepository? _clientRepo;
        public IBuyerRepository? _buyerRepo;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {

            _context = context;
        }

        public IClientRepository ClientRepository
        {
            //Verificar se tenho 
            //uma instancia se não tiver vou criar uma
            get
            {
                return _clientRepo = _clientRepo ?? new ClientRepository(_context);
            }
        }

        public IBuyerRepository BuyerRepository
        {
            get
            {
                return _buyerRepo = _buyerRepo ?? new BuyerRepository(_context);
            }
        }



        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }
    }


}

