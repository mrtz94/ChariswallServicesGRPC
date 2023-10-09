using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISupplyLogRepository : IQueryRepository<SupplyLog>, ICommandRepository<SupplyLog>
    {
        SupplyLog? GetSupplyLastLog(int supplyCode);
    }
}
