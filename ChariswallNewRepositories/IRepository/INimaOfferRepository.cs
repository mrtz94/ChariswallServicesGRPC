using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaOfferRepository : IQueryRepository<NimaOffer>, ICommandRepository<NimaOffer>
    {
        List<NimaOffer> GetNewOffers();
        List<NimaOffer> GetUnfinishedOffers();
    }
}
