using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SupplyLogRepository : ChariswallRepository<SupplyLog>, ISupplyLogRepository
    {
        public SupplyLogRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public SupplyLog? GetSupplyLastLog(int supplyCode)
        {
            return _context.SupplyLogs.Where(o => o.SupplyCode == supplyCode).OrderByDescending(o => o.ServerDateTime).ToList().FirstOrDefault();
        }
    }
}
