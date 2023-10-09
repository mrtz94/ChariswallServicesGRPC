using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IRequestActiveRepository : IQueryRepository<RequestActive>, ICommandRepository<RequestActive>
    {
    }
}
