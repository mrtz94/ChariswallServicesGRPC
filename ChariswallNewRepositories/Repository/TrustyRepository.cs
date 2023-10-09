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
    public class TrustyRepository : ChariswallRepository<Trusty>, ITrustyRepository
    {
        public TrustyRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
