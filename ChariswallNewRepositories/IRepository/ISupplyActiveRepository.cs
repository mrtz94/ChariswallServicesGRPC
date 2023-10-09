using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISupplyActiveRepository : IQueryRepository<SupplyActive>, ICommandRepository<SupplyActive>
    {
    }
}
