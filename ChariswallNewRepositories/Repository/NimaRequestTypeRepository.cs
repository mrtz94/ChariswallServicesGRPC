using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaRequestTypeRepository : ChariswallRepository<NimaRequestType>, INimaRequestTypeRepository
    {
        public NimaRequestTypeRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetRequestType(string rttitle)
        {
            var rtId = _context.NimaRequestTypes.FirstOrDefault(f => f.Title == rttitle)?.Id;
            if (rtId == null)
            {
                var lastVal = _context.NimaRequestTypes.Max(m => m.Value);
                var rt = new NimaRequestType { Title = rttitle, Value = lastVal + 1 };
                _context.NimaRequestTypes.Add(rt);
                _context.SaveChanges();
                rtId = rt.Id;
            }
            return rtId ?? 0;
        }
    }
}
