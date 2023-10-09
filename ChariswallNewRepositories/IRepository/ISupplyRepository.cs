using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISupplyRepository : IQueryRepository<Supply>, ICommandRepository<Supply>
    {
        List<Supply> GetNewSupplies();
    }
}
