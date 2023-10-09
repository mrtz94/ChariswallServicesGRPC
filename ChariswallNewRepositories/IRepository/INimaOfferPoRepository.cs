using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaOfferPoRepository : IQueryRepository<NimaOfferPo>, ICommandRepository<NimaOfferPo>
    {
    }
}
