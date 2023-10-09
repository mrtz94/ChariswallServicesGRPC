using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class ValidityCheckRepository : ChariswallRepository<ValidityCheck>, IValidityCheckRepository
    {
        public ValidityCheckRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetVCheck(string vcheckname)
        {
            var vcId = _context.ValidityChecks.FirstOrDefault(f => f.Title == vcheckname)?.Id;
            if (vcId == null)
            {
                var vc = new ValidityCheck { Title = vcheckname };
                _context.ValidityChecks.Add(vc);
                _context.SaveChanges();
                vcId = vc.Id;
            }
            return vcId ?? 0;
        }
    }
}
