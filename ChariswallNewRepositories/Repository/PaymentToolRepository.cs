using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class PaymentToolRepository : ChariswallRepository<PaymentTool>, IPaymentToolRepository
    {
        public PaymentToolRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetTool(string paytool)
        {
            var paytId = _context.PaymentTools.FirstOrDefault(f => f.Title == paytool)?.Id;
            if (paytId == null)
            {
                var payt = new PaymentTool { Title = paytool };
                _context.PaymentTools.Add(payt);
                _context.SaveChanges();
                paytId = payt.Id;
            }
            return paytId ?? 0;
        }
    }
}
