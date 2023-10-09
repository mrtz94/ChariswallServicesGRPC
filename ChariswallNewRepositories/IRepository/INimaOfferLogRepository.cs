using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaOfferLogRepository : IQueryRepository<NimaOfferLog>, ICommandRepository<NimaOfferLog>
    {
        NimaOfferLog? GetOfferLastLog(int offerCode);
    }
}
