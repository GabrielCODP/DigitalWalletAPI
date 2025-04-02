using CardDigitalAPI.Context;
using CardDigitalAPI.Models;
using CardDigitalAPI.Repositories.Interfaces;

namespace CardDigitalAPI.Repositories
{
    public class BuyerRepository : Repository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(AppDbContext context) : base(context)
        {

        }
    }
}
