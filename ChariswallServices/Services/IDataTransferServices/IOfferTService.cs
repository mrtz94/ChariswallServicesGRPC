using ChariswallNewDomain.Models;
using ChariswallServices.Protos;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface IOfferTService
    {
        List<NimaOfferActive> NimaOffersActiveTransfer(List<OfferRecord> offers);
        ChariswallNewDomain.Models.NimaOffer OfferTransfer(OfferRecord record);
        NimaOfferLog OfferLogTransfer(OfferRecord record);
        bool CompareOfferLog(OfferRecord record, NimaOfferLog log);
        void OfferFill(OfferRecord record, ref ChariswallNewDomain.Models.NimaOffer offer);
        bool CompareOfferDetailLog(OfferDetailRecord record, NimaOfferLog log);
        NimaOfferLog OfferDetailLogTransfer(OfferDetailRecord record, ChariswallNewDomain.Models.NimaOffer offer);
        void OfferDetailFill(OfferDetailRecord record, ref ChariswallNewDomain.Models.NimaOffer offer, ref NimaOfferActive offerActive, ref Request? request);
        NimaOfferPayment NimaOfferPaymentTransfer(PaymentRecordOffer payment, int offerCode);
        NimaOfferPo NimaOfferPOTransfer(PORecord po, int offerCode);
        OfferOutRecord NewOfferTransfer(ChariswallNewDomain.Models.NimaOffer offer);
    }
}
