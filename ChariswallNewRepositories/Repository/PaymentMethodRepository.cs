using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class PaymentMethodRepository : ChariswallRepository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetMethod(string paymethod)
        {
            var paymId = _context.PaymentMethods.FirstOrDefault(f => f.Title == paymethod)?.Id;
            if (paymId == null)
            {
                var paym = new PaymentMethod { Title = paymethod };
                _context.PaymentMethods.Add(paym);
                _context.SaveChanges();
                paymId = paym.Id;
            }
            return paymId ?? 0;
        }
    }
}
