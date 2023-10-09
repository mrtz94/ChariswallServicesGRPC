using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SanaPaymentRepository : ChariswallRepository<SanaPayment>, ISanaPaymentRepository
    {
        public SanaPaymentRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
