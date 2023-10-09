using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaDealActiveRepository : IQueryRepository<NimaDealActive>, ICommandRepository<NimaDealActive>
    {
        void RemoveDemands();
        void RemoveDeals();
    }
}
