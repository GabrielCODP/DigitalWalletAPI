using CardDigitalAPI.Context;
using CardDigitalAPI.Models;
using CardDigitalAPI.Repositories.Interfaces;

namespace CardDigitalAPI.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(AppDbContext context) : base(context) 
        { }
    }
}
