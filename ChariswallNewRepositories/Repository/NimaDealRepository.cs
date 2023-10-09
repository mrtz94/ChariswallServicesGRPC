using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaDealRepository : ChariswallRepository<NimaDeal>, INimaDealRepository
    {
        public NimaDealRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public List<NimaDeal> GetNewDemands()
        {
            return _context.NimaDeals.Where(w => !(w.IsDeal ?? false) && !string.IsNullOrWhiteSpace(w.DemandDetailLink) && w.ServerDateTimeRead > DateTime.Today.AddDays(-3)).ToList();
        }

        public List<NimaDeal> GetNewDeals()
        {
            return _context.NimaDeals.Where(w => (w.IsDeal ?? false) && w.DealDetailRead == 0 && w.ServerDateTimeRead > DateTime.Today.AddDays(-3)).ToList();
        }

        public List<NimaDeal> GetUnfinishedDeals()
        {
            return _context.NimaDeals.Where(w => (w.IsDeal ?? false) && w.StatusText != "مختومه" && w.StatusText != "حذف شده" && w.StatusText != "رد شده" && w.StatusText != "لغو شده" && w.StatusText != "انصراف صراف از معامله").ToList();
        }
    }
}
