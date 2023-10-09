using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IRequestRepository : IQueryRepository<Request>, ICommandRepository<Request>
    {
        List<Request> GetNewRequests();
    }
}
