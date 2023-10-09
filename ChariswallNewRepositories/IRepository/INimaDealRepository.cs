using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaDealRepository : IQueryRepository<NimaDeal>, ICommandRepository<NimaDeal>
    {
        List<NimaDeal> GetNewDemands();
        List<NimaDeal> GetNewDeals();
        List<NimaDeal> GetUnfinishedDeals();

    }
}
