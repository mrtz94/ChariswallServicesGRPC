using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SanaOrderReasonRepository : ChariswallRepository<SanaOrderReason>, ISanaOrderReasonRepository
    {
        public SanaOrderReasonRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
