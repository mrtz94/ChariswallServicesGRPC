using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaOfferRepository : ChariswallRepository<NimaOffer>, INimaOfferRepository
    {
        public NimaOfferRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public List<NimaOffer> GetNewOffers()
        {
            var offersinput2 = _context.NimaOffers.Where(w => w.OfferDetailRead == 0 && w.ServerDateTimeRead > DateTime.Today.AddDays(-30)).ToList();
            var oi1 = offersinput2.Where(w => w.StatusText == "منتظر انتخاب متقاضی" || w.StatusText == "تعلیق شده").OrderByDescending(o => o.Status);
            var oi2 = offersinput2.Where(w => w.StatusText != "منتظر انتخاب متقاضی" && w.StatusText != "تعلیق شده");
            return oi2.Concat(oi1).ToList();
        }

        public List<NimaOffer> GetUnfinishedOffers()
        {
            var offersinput2 = _context.NimaOffers.Where(w => w.StatusText != "تعلیق شده" && w.StatusText != "مختومه" && w.StatusText != "رد شده" && w.StatusText != "لغو شده" && w.StatusText != "نامشخص"
                 && w.StatusText != "انصراف متقاضی" && w.StatusText != "انصراف صراف" && w.StatusText != "بدون وضعیت" &&
                 ((w.StatusText != "منتظر انتخاب متقاضی" && w.ServerDateTimeRead > DateTime.Today.AddDays(-300)) || (w.StatusText == "منتظر انتخاب متقاضی" && w.ServerDateTimeRead > DateTime.Today.AddDays(-3)))).ToList();
            return offersinput2.Where(w => w.OfferDetailRead == 0).OrderByDescending(o => o.RequestCode).Distinct().ToList();
        }
    }
}
