using ChariswallNewDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChariswallNewRepositories.IRepository
{
    public interface IActiveSystemRepository : IQueryRepository<ActiveSystem>, ICommandRepository<ActiveSystem>
    {
    }
}
