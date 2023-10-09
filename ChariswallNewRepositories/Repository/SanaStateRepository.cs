using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SanaStateRepository : ChariswallRepository<SanaState>, ISanaStateRepository
    {
        public SanaStateRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetState(string stateName)
        {

            var stateId = _context.SanaStates.FirstOrDefault(f => f.Title == stateName)?.Id;
            if (stateId == null)
            {
                var state = new SanaState { Title = stateName };
                _context.SanaStates.Add(state);
                _context.SaveChanges();
                stateId = state.Id;
            }
            return stateId ?? 0;
        }
    }
}
