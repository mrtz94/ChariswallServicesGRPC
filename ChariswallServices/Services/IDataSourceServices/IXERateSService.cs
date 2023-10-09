using ChariswallServices.Protos;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface IXERateSService
    {
        void ProcessRates(List<xerateInput> rates);
    }
}
