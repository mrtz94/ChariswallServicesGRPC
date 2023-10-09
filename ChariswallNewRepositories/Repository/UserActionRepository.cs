using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class UserActionRepository : ChariswallRepository<UserAction>, IUserActionRepository
    {
        public UserActionRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
