using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class RegistererTypeRepository : ChariswallRepository<RegistererType>, IRegistererTypeRepository
    {
        public RegistererTypeRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetRegistererType(string rttitle)
        {
            var rtId = _context.RegistererTypes.FirstOrDefault(f => f.Title == rttitle)?.Id;
            if (rtId == null)
            {
                var rt = new RegistererType { Title = rttitle };
                _context.RegistererTypes.Add(rt);
                _context.SaveChanges();
                rtId = rt.Id;
            }
            return rtId ?? 0;
        }
    }
}
