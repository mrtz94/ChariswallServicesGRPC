using ChariswallServices.Protos;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;
using Google.Protobuf.WellKnownTypes;
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

        public override Task<OfferList> GetAllOffers(Empty input, ServerCallContext context)
        {
            try
            {
                var output = _service.GetAllOffers();
                return Task.FromResult(output);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OfferList());
            }
        }
        public override Task<ChariswallOfferList> GetOpenOffers(Empty input, ServerCallContext context)
        {
            try
            {
                var output = _service.GetOpenOffers();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<ChariswallOfferList> GetActiveOffers(Empty input, ServerCallContext context)
        {
            try
            {
                var output = _service.GetActiveOffers();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<ChariswallOfferList> GetActiveOfferCount(Empty input, ServerCallContext context)
        {
            try
            {
                var output = _service.GetActiveOfferCount();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<OfferLogList> GetOfferHistory(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.GetOfferHistory();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<ChariswallOfferList> GetFinishedOffers(Empty input, ServerCallContext context)
        {
            try
            {
                var output = _service.GetFinishedOffers();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<ChariswallOfferRecord> GetOffer(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.GetOffer();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<OfferIdResponse> AutoOfferRegister(AutoOffersDTO input, ServerCallContext context)
        {
            try
            {
                var output = _service.AutoOfferRegister();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<OfferIdResponse> RegisterOffer(ChariswallOfferRecord input, ServerCallContext context)
        {
            try
            {
                var output = _service.RegisterOffer();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<Empty> EditOffer(ChariswallOfferRecord input, ServerCallContext context)
        {
            try
            {
                var output = _service.EditOffer();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<Empty> DeleteOffer(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.DeleteOffer();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<Empty> DeleteUnregisteredOffer(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.DeleteUnregisteredOffer();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<Empty> ConfirmOffer(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.ConfirmOffer();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<Empty> RejectOffer(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.RejectOffer();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<Empty> DiscardOffer(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.DiscardOffer();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<Empty> ResetOfferStatus(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.ResetOfferStatus();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<OfferIdResponse> PaymentOrderUpload(OfferPO input, ServerCallContext context)
        {
            try
            {
                var output = _service.PaymentOrderUpload();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<OfferIdResponse> ConfirmPaymentOrder(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.ConfirmPaymentOrder();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<PayList> GetPayments(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.GetPayments();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<POList> GetPOs(OfferIdResponse input, ServerCallContext context)
        {
            try
            {
                var output = _service.GetPOs();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<Empty> SetPONumber(PayInput input, ServerCallContext context)
        {
            try
            {
                var output = _service.SetPONumber();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<Empty> ConfirmPayment(PayInput input, ServerCallContext context)
        {
            try
            {
                var output = _service.ConfirmPayment();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<Empty> RejectPayment(PayInput input, ServerCallContext context)
        {
            try
            {
                var output = _service.RejectPayment();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
        public override Task<UserProfileSaleOutput> SaleProfile(UserProfileSaleInput input, ServerCallContext context)
        {
            try
            {
                var output = _service.SaleProfile();
                return Task.FromResult(new { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new());
            }
        }
    }
}
