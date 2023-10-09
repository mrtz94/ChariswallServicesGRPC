using ChariswallNewDomain.Models;
using ChariswallServices.Protos;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface IDealTService
    {
        List<NimaDealActive> NimaDemandsActiveTransfer(List<DemandRecord> demands);
        ChariswallNewDomain.Models.NimaDeal DemandTransfer(DemandRecord record);
        NimaDealLog DemandLogTransfer(DemandRecord record);
        bool CompareDemandLog(DemandRecord record, NimaDealLog log);
        void DemandFill(DemandRecord record, ref ChariswallNewDomain.Models.NimaDeal deal);
        List<NimaDealActive> NimaDealsActiveTransfer(List<DealRecord> deals);
        ChariswallNewDomain.Models.NimaDeal DealTransfer(DealRecord record);
        NimaDealLog DealLogTransfer(DealRecord record);
        bool CompareDealLog(DealRecord record, NimaDealLog log);
        void DealFill(DealRecord record, ref ChariswallNewDomain.Models.NimaDeal deal);
        bool CompareDemandDetailLog(DemandDetailRecord record, NimaDealLog log);
        NimaDealLog DemandDetailLogTransfer(DemandDetailRecord record);
        void DemandDetailFill(DemandDetailRecord record, ref ChariswallNewDomain.Models.NimaDeal demand, ref NimaDealActive demandActive, ref Supply supply);
        bool CompareDealDetailLog(DealDetailRecord record, NimaDealLog log);
        NimaDealLog DealDetailLogTransfer(DealDetailRecord record);
        void DealDetailFill(DealDetailRecord record, ref ChariswallNewDomain.Models.NimaDeal deal, ref NimaDealActive dealActive, ref Supply? supply);
        NimaDealPayment NimaDealPaymentTransfer(PaymentRecordDeal payment, int offerCode);
        DemandOutRecord NewDemandTransfer(ChariswallNewDomain.Models.NimaDeal demand);
        DealOutRecord NewDealTransfer(ChariswallNewDomain.Models.NimaDeal deal);
    }
}
