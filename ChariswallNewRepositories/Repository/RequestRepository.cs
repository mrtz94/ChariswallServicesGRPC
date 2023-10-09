using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class RequestRepository : ChariswallRepository<Request>, IRequestRepository
    {
        public RequestRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public List<Request> GetNewRequests()
        {
            var RequestsFromOffers = _context.NimaOffers.Where(w => w.RequestDetailRead == 0).ToList().Select(s => new Request(s)).ToList();
            var Requests = _context.Requests.Where(w => !(w.DetailRead ?? false) && w.ServerDateTimeRead > DateTime.Today.AddDays(-3)).ToList();
            return Requests.Concat(RequestsFromOffers).ToList();
        }
    }
}
