using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaOfferStateRepository : ChariswallRepository<NimaOfferState>, INimaOfferStateRepository
    {
        public NimaOfferStateRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetOfferState(string statetitle)
        {
            var stateId = _context.NimaOfferStates.FirstOrDefault(f => f.Title == statetitle)?.Id;
            if (stateId == null)
            {
                var lastVal = _context.NimaOfferStates.Max(m => m.Value);
                var state = new NimaOfferState { Title = statetitle, Etitle = "", Value = lastVal + 1 };
                _context.NimaOfferStates.Add(state);
                _context.SaveChanges();
                stateId = state.Id;
            }
            return stateId ?? 0;
        }
    }
}
