using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaOfferLogRepository : ChariswallRepository<NimaOfferLog>, INimaOfferLogRepository
    {
        public NimaOfferLogRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public NimaOfferLog? GetOfferLastLog(int offerCode)
        {
            return _context.NimaOfferLogs.Where(o => o.OfferCode == offerCode).OrderByDescending(o => o.LastUpdateTime).ToList().FirstOrDefault();
        }
    }
}
