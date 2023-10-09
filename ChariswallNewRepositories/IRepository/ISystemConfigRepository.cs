using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISystemConfigRepository : IQueryRepository<SystemConfig>, ICommandRepository<SystemConfig>
    {
    }
}
