using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaRequestStateRepository : ChariswallRepository<NimaRequestState>, INimaRequestStateRepository
    {
        public NimaRequestStateRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetRequestState(string rstitle)
        {
            var rsId = _context.NimaRequestStates.FirstOrDefault(f => f.Title == rstitle)?.Id;
            if (rsId == null)
            {
                var lastVal = _context.NimaRequestStates.Max(m => m.Value);
                var rs = new NimaRequestState { Title = rstitle, Value = lastVal + 1 };
                _context.NimaRequestStates.Add(rs);
                _context.SaveChanges();
                rsId = rs.Id;
            }
            return rsId ?? 0;
        }
    }
}
