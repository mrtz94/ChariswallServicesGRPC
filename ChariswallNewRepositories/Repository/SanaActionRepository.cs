using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SanaActionRepository : ChariswallRepository<SanaAction>, ISanaActionRepository
    {
        public SanaActionRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetAction(string actionName)
        {
            var actionId = _context.SanaActions.FirstOrDefault(f => f.Title == actionName)?.Id;
            if (actionId == null)
            {
                var action = new SanaAction { Title = actionName };
                _context.SanaActions.Add(action);
                _context.SaveChanges();
                actionId = action.Id;
            }
            return actionId ?? 0;
        }
    }
}
