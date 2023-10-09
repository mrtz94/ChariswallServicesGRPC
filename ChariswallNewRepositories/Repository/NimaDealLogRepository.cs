using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaDealLogRepository : ChariswallRepository<NimaDealLog>, INimaDealLogRepository
    {
        public NimaDealLogRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public NimaDealLog? GetDealLastLog(int DealCode)
        {
            return _context.NimaDealLogs.Where(o => o.TradeCode == DealCode).OrderByDescending(o => o.ServerDateTimeRead).ToList().FirstOrDefault();
        }

        public NimaDealLog? GetDemandLastLog(int DemandCode)
        {
            return _context.NimaDealLogs.Where(o => o.DemandCode == DemandCode).OrderByDescending(o => o.ServerDateTimeRead).ToList().FirstOrDefault();
        }
    }
}
