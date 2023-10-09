using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IExpertLevelRepository : IQueryRepository<ExpertLevel>, ICommandRepository<ExpertLevel>
    {
    }
}
