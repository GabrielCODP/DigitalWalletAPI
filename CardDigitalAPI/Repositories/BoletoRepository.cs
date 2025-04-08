using CardDigitalAPI.Context;
using CardDigitalAPI.Models;
using CardDigitalAPI.Repositories.Interfaces;

namespace CardDigitalAPI.Repositories
{
    public class BoletoRepository : Repository<Boleto>, IBoletoRepository
    {
        public BoletoRepository(AppDbContext context) : base(context)
        { }
    }
}
