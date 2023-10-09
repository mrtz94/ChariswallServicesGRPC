using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IUserActionRepository : IQueryRepository<UserAction>, ICommandRepository<UserAction>
    {
    }
}
