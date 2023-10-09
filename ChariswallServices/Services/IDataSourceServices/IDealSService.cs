using ChariswallServices.Protos;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface IDealSService
    {
        void processDemands(List<DemandRecord> Demands);
        void processDeals(List<DealRecord> Deals);
        void processDemandDetail(DemandDetailRecord record);
        void processsDealDetail(DealDetailRecord record);
        NewDemands getNewDemands();
        NewDeals getNewDeals();
        NewDeals getUnfinishedDeals();
        string buysLastDate();
        void ProcessNimaDealPayments(List<PaymentRecordDeal> payments, int tradeCode);
    }
}
