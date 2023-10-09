using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SupplyRepository : ChariswallRepository<Supply>, ISupplyRepository
    {
        public SupplyRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public List<Supply> GetNewSupplies()
        {
            return _context.Supplies.Where(w => w.DetailRead == 0 && w.ServerDateTimeRead > DateTime.Today.AddDays(-3)).ToList();
        }
    }
}
