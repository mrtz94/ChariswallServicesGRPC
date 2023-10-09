using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaOfferActiveRepository : ChariswallRepository<NimaOfferActive>, INimaOfferActiveRepository
    {
        public NimaOfferActiveRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
