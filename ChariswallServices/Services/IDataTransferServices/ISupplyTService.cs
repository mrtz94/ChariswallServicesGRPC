using ChariswallNewDomain.Models;
using ChariswallServices.Protos;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface ISupplyTService
    {
        List<SupplyActive> NimaSuppliesActiveTransfer(List<SupplyRecord> supplies);
        Supply SupplyTransfer(SupplyRecord record);
        SupplyLog SupplyLogTransfer(SupplyRecord record);
        bool CompareSupplyLog(SupplyRecord record, SupplyLog log);
        void SupplyFill(SupplyRecord record, ref Supply supply);
        bool CompareSupplyDetailLog(SupplyDetailRecord record, SupplyLog log);
        SupplyLog SupplyDetailLogTransfer(SupplyDetailRecord record);
        void SupplyDetailFill(SupplyDetailRecord record, ref Supply supply, ref SupplyActive supplyActive, ref List<ChariswallNewDomain.Models.NimaDeal> deals);
        SupplyOutRecord NewSupplyTransfer(Supply supply);
    }
}
