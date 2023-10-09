using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaTransferTypeRepository : ChariswallRepository<NimaTransferType>, INimaTransferTypeRepository
    {
        public NimaTransferTypeRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetTransferType(string tt)
        {
            var ttypeId = _context.NimaTransferTypes.FirstOrDefault(f => f.Title == tt)?.Id;
            if (ttypeId == null)
            {
                var lastVal = _context.NimaTransferTypes.Max(m => m.Value);
                var ttype = new NimaTransferType { Title = tt, Value = (lastVal + 1) };
                _context.NimaTransferTypes.Add(ttype);
                _context.SaveChanges();
                ttypeId = ttype.Id;
            }
            return ttypeId ?? 0;
        }
    }
}
