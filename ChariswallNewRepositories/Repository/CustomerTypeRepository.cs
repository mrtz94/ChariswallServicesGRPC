using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class CustomerTypeRepository : ChariswallRepository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetCType(string ctypeName)
        {
            var ctypeId = _context.CustomerTypes.FirstOrDefault(f => f.Title == ctypeName)?.Id;
            if (ctypeId == null)
            {
                var lastVal = _context.CustomerTypes.Max(m => m.Value);
                var ctype = new CustomerType { Title = ctypeName, Value = (lastVal + 1) };
                _context.CustomerTypes.Add(ctype);
                _context.SaveChanges();
                ctypeId = ctype.Id;
            }
            return ctypeId ?? 0;
        }
    }
}
