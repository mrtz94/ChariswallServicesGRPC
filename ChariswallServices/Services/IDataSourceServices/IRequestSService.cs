using ChariswallServices.Protos;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface IRequestSService
    {
        void processRequests(List<RequestRecord> requests);
        void processRequestDetail(RequestDetailRecord record);
        NewRequests getNewRequests();
        bool CheckRequest(int rc);
    }
}
