using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaDealPaymentRepository : ChariswallRepository<NimaDealPayment>, INimaDealPaymentRepository
    {
        public NimaDealPaymentRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
