using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaOfferPoRepository : ChariswallRepository<NimaOfferPo>, INimaOfferPoRepository
    {
        public NimaOfferPoRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
