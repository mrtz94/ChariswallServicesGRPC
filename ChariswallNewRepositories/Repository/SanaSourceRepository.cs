using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChariswallNewRepositories.Repository
{
    public class SanaSourceRepository : ChariswallRepository<SanaSource>, ISanaSourceRepository
    {
        public SanaSourceRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetSource(string sourceName)
        {

            var sourceId = _context.SanaSources.FirstOrDefault(f => f.Title == sourceName)?.Id;
            if (sourceId == null)
            {
                var lastVal = _context.SanaSources.Max(m => m.Value);
                var source = new SanaSource { Title = sourceName, Value = (lastVal + 1) };
                _context.SanaSources.Add(source);
                _context.SaveChanges();
                sourceId = source.Id;
            }
            return sourceId ?? 0;
        }
    }
}
