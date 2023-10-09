using ChariswallServices.Protos;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface IOfferSService
    {
        void processOffers(List<OfferRecord> Offers);
        void processOfferDetail(OfferDetailRecord record);
        void ProcessNimaOfferPayments(List<PaymentRecordOffer> payments, int offerCode);
        void ProcessNimaOfferPOs(List<PORecord> records, int offerCode);
        NewOffers getNewOffers();
        NewOffers getUnfinishedOffers();
        string salesLastDate();
    }
}
