using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaOfferPaymentRepository : ChariswallRepository<NimaOfferPayment>, INimaOfferPaymentRepository
    {
        public NimaOfferPaymentRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
