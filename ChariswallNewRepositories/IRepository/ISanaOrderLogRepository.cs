using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISanaOrderLogRepository : IQueryRepository<SanaOrderLog>, ICommandRepository<SanaOrderLog>
    {
    }
}
