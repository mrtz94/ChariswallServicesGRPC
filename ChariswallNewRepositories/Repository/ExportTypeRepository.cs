using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class ExportTypeRepository : ChariswallRepository<ExportType>, IExportTypeRepository
    {
        public ExportTypeRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetExportType(string et)
        {
            var etypeId = _context.ExportTypes.FirstOrDefault(f => f.Title == et)?.Id;
            if (etypeId == null)
            {
                var lastVal = _context.ExportTypes.Max(m => m.Value);
                var etype = new ExportType { Title = et, Value = (lastVal + 1) };
                _context.ExportTypes.Add(etype);
                _context.SaveChanges();
                etypeId = etype.Id;
            }
            return etypeId ?? 0;
        }
    }
}
