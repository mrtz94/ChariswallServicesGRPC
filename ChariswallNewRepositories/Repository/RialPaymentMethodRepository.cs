using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class RialPaymentMethodRepository : ChariswallRepository<RialPaymentMethod>, IRialPaymentMethodRepository
    {
        public RialPaymentMethodRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetMethod(string rpm)
        {
            var rpmId = _context.RialPaymentMethods.FirstOrDefault(f => f.Title == rpm)?.Id;
            if (rpmId == null)
            {
                var method = new RialPaymentMethod { Title = rpm };
                _context.RialPaymentMethods.Add(method);
                _context.SaveChanges();
                rpmId = method.Id;
            }
            return rpmId ?? 0;
        }
    }
}
