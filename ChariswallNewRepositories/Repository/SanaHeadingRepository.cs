using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SanaHeadingRepository : ChariswallRepository<SanaHeading>, ISanaHeadingRepository
    {
        public SanaHeadingRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetHeading(string headingName)
        {
            var heaingId = _context.SanaHeadings.FirstOrDefault(f => f.Title == headingName)?.Id;
            if (heaingId == null)
            {
                var lastVal = _context.SanaHeadings.Max(m => m.Value);
                var heading = new SanaHeading { Title = headingName, Value = (lastVal + 1) };
                _context.SanaHeadings.Add(heading);
                _context.SaveChanges();
                heaingId = heading.Id;
            }
            return heaingId ?? 0;
        }
    }
}
