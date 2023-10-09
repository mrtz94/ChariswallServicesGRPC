using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaRateTypeRepository : ChariswallRepository<NimaRateType>, INimaRateTypeRepository
    {
        public NimaRateTypeRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetRateType(string rttitle)
        {
            var rtId = _context.NimaRateTypes.FirstOrDefault(f => f.Title == rttitle)?.Id;
            if (rtId == null)
            {
                var rt = new NimaRateType { Title = rttitle };
                _context.NimaRateTypes.Add(rt);
                _context.SaveChanges();
                rtId = rt.Id;
            }
            return rtId ?? 0;
        }
    }
}
