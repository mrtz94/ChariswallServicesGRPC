using ChariswallNewDomain.Models;
using ChariswallServices.Protos;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface IRequestTService
    {
        List<RequestActive> NimaRequestsActiveTransfer(List<RequestRecord> requests);
        Request RequestTransfer(RequestRecord record);
        RequestLog RequestLogTransfer(RequestRecord record);
        bool CompareRequestLog(RequestRecord record, RequestLog log);
        void RequestFill(RequestRecord record, ref Request request);
        bool CompareRequestDetailLog(RequestDetailRecord record, RequestLog log);
        RequestLog RequestDetailLogTransfer(RequestDetailRecord record);
        void RequestDetailFill(RequestDetailRecord record, ref Request request, ref RequestActive requestActive, ref List<ChariswallNewDomain.Models.NimaOffer> offers);
        RequestOutRecord NewRequestTransfer(Request request);
    }
}
