using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class DealTypeRepository : ChariswallRepository<DealType>, IDealTypeRepository
    {
        public DealTypeRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetDealType(string dealtypeName)
        {
            var dtypeId = _context.DealTypes.FirstOrDefault(f => f.Title == dealtypeName)?.Id;
            if (dtypeId == null)
            {
                int lastval = 0;
                try
                {
                    lastval = _context.DealTypes.Max(m => m.Value);
                }
                catch { }
                var dtype = new DealType { Title = dealtypeName, Value = (lastval + 1) };
                _context.DealTypes.Add(dtype);
                _context.SaveChanges();
                dtypeId = dtype.Id;
            }
            return dtypeId ?? 0;
        }
    }
}
