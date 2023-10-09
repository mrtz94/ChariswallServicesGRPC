using Azure.Core;
using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class RequestLogRepository : ChariswallRepository<RequestLog>, IRequestLogRepository
    {
        public RequestLogRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public RequestLog? GetRequestLastLog(int requestCode)
        {
            return _context.RequestLogs.Where(o => o.RequestCode == requestCode).OrderByDescending(o => o.ServerDateTime).ToList().FirstOrDefault();
        }
    }
}
