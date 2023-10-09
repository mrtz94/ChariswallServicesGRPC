using ChariswallServices.Protos;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;
using Grpc.Core;

namespace ChariswallServices.Services.ProtoServices
{
    public class NimaOfferService : NimaOffer.NimaOfferBase
    {
        IOfferSService _service;
        public NimaOfferService(IOfferSService service)
        {
            _service = service;
        }
        public override Task<ResultOutputOffer> ProcessOffers(OfferInput input, ServerCallContext context)
        {
            try
            {
                _service.processOffers(input.Offers.ToList());
                return Task.FromResult(new ResultOutputOffer { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputOffer { Result = false });
            }
        }
        public override Task<ResultOutputOffer> ProcessOfferDetail(OfferDetailInput input, ServerCallContext context)
        {
            try
            {
                _service.processOfferDetail(input.Offer);
                return Task.FromResult(new ResultOutputOffer { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputOffer { Result = false });
            }
        }

        public override Task<ResultOutputOffer> ProcessOfferPayments(NimaPaymentInputOffer input, ServerCallContext context)
        {
            try
            {
                _service.ProcessNimaOfferPayments(input.Pays.ToList(), input.Code);
                return Task.FromResult(new ResultOutputOffer { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputOffer { Result = false });
            }
        }
        public override Task<ResultOutputOffer> ProcessOfferPOs(NimaOfferPOInput input, ServerCallContext context)
        {
            try
            {
                _service.ProcessNimaOfferPOs(input.POs.ToList(), input.OfferCode);
                return Task.FromResult(new ResultOutputOffer { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputOffer { Result = false });
            }
        }
        public override Task<NewOffers> GetNewOffers(GeneralInputOOffer input, ServerCallContext context)
        {
            try
            {
                var output = _service.getNewOffers();
                return Task.FromResult(output);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new NewOffers());
            }
        }

        public override Task<NewOffers> GetUnfinishedOffers(GeneralInputOOffer input, ServerCallContext context)
        {
            try
            {
                var output = _service.getUnfinishedOffers();
                return Task.FromResult(output);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new NewOffers());
            }
        }
        public override Task<LastDateOutputOffer> GetSalesLastDate(GeneralInputOOffer input, ServerCallContext context)
        {
            try
            {
                var output = _service.salesLastDate();
                return Task.FromResult(new LastDateOutputOffer { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new LastDateOutputOffer());
            }
        }
    }
}
