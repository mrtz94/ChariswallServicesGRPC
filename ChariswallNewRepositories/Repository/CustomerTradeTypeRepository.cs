using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class CustomerTradeTypeRepository : ChariswallRepository<CustomerTradeType>, ICustomerTradeTypeRepository
    {
        public CustomerTradeTypeRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
