using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;
using System.Linq;

namespace ChariswallNewRepositories.Repository
{
    public class NimaDealActiveRepository : ChariswallRepository<NimaDealActive>, INimaDealActiveRepository
    {
        public NimaDealActiveRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public void RemoveDemands()
        {
            _context.NimaDealActives.RemoveRange(_context.NimaDealActives.Where(w => !(w.IsDeal ?? false)));
        }

        public void RemoveDeals()
        {
            _context.NimaDealActives.RemoveRange(_context.NimaDealActives.Where(w => (w.IsDeal ?? false)));
        }
    }
}
