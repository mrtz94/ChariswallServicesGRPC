using ChariswallServices.Protos;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface ISupplySService
    {
        void processSupplies(List<SupplyRecord> supplies);
        void processSupplyDetail(SupplyDetailRecord record);
        NewSupplies getNewSupplies();
    }
}
