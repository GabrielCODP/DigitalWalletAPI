using CardDigitalAPI.Context;
using CardDigitalAPI.Models;
using CardDigitalAPI.Repositories.Interfaces;

namespace CardDigitalAPI.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context) 
        { 
        }
    }
}
