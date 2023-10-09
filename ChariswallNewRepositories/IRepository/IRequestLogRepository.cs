using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IRequestLogRepository : IQueryRepository<RequestLog>, ICommandRepository<RequestLog>
    {
        RequestLog? GetRequestLastLog(int requestCode);
    }
}
