using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaDealLogRepository : IQueryRepository<NimaDealLog>, ICommandRepository<NimaDealLog>
    {
        NimaDealLog? GetDealLastLog(int DealCode);
        NimaDealLog? GetDemandLastLog(int DemandCode);
    }
}
