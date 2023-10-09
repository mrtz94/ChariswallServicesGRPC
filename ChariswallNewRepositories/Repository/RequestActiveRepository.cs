using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class RequestActiveRepository : ChariswallRepository<RequestActive>, IRequestActiveRepository
    {
        public RequestActiveRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
