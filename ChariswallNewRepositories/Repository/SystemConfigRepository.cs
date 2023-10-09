using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SystemConfigRepository : ChariswallRepository<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
