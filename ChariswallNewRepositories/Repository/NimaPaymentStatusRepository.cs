using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaPaymentStatusRepository : ChariswallRepository<NimaPaymentStatus>, INimaPaymentStatusRepository
    {
        public NimaPaymentStatusRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetPayStatus(string paystatusname)
        {
            var paystatusId = _context.NimaPaymentStatuses.FirstOrDefault(f => f.Title == paystatusname)?.Id;
            if (paystatusId == null)
            {
                var paystatus = new NimaPaymentStatus { Title = paystatusname };
                _context.NimaPaymentStatuses.Add(paystatus);
                _context.SaveChanges();
                paystatusId = paystatus.Id;
            }
            return paystatusId ?? 0;
        }
    }
}
