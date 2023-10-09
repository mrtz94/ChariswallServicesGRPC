using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaOfferPaymentRepository : IQueryRepository<NimaOfferPayment>, ICommandRepository<NimaOfferPayment>
    {
    }
}
