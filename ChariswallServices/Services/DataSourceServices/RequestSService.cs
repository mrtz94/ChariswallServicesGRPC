using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Protos;
using ChariswallServices.Services.IDataSourceServices;

namespace ChariswallServices.Services.DataSourceServices
{
    public class RequestSService : IRequestSService
    {
        IUnitOfWork _unitOfWork;
        IRequestTService _dataTransferService;
        public RequestSService(IUnitOfWork unitOfWork, IRequestTService dataTransferService)
        {
            _unitOfWork = unitOfWork;
            _dataTransferService = dataTransferService;
        }
        public bool CheckRequest(int rc)
        {
            return _unitOfWork.requests.Find(f => f.RequestCode == rc).Count() > 0;
        }
        public void processRequests(List<RequestRecord> requests)
        {
            if (requests.Count > 0)
            {
                ProcessActiveRequests(requests);
                ProcessRequestsRecords(requests);
            }
        }

        private void ProcessActiveRequests(List<RequestRecord> requests)
        {
            _unitOfWork.requestsActive.RemoveAll();
            _unitOfWork.Complete();
            _unitOfWork.requestsActive.AddRange(_dataTransferService.NimaRequestsActiveTransfer(requests));
            _unitOfWork.Complete();
        }

        private void ProcessRequestsRecords(List<RequestRecord> requests)
        {
            foreach (var request in requests)
            {

                Request requestmain = _dataTransferService.RequestTransfer(request);
                var oldReq = _unitOfWork.requests.Find(f => f.RequestCode == request.RequestCode).FirstOrDefault();
                if (oldReq == null)
                    _unitOfWork.requests.Add(requestmain);
                else
                {
                    _dataTransferService.RequestFill(request, ref oldReq);
                    _unitOfWork.requests.Edit(oldReq);
                }
            }
            _unitOfWork.Complete();
        }

        public void processRequestDetail(RequestDetailRecord record)
        {
            var request = _unitOfWork.requests.Find(f => f.RequestCode == record.RequestCode).FirstOrDefault();
            var requestActive = _unitOfWork.requestsActive.Find(f => f.RequestCode == record.RequestCode).FirstOrDefault();
            var log = _dataTransferService.RequestDetailLogTransfer(record);
            var nimaoffers = _unitOfWork.offers.Find(f => f.RequestCode == record.RequestCode && f.RequestDetailRead == 0).ToList();

            if ((request != null && (request.DetailRead ?? false) && !_dataTransferService.CompareRequestDetailLog(record, log)) || (request != null && !(request.DetailRead ?? false)))
            {
                var newLog = _dataTransferService.RequestDetailLogTransfer(record);
                _dataTransferService.RequestDetailFill(record, ref request, ref requestActive, ref nimaoffers);
                _unitOfWork.requests.Edit(request);
                if (requestActive != null)
                    _unitOfWork.requestsActive.Edit(requestActive);
                _unitOfWork.requestsLog.Add(newLog);
                if (nimaoffers.Count() > 0)
                    _unitOfWork.offers.EditRange(nimaoffers);
                _unitOfWork.Complete();
            }
        }
        public NewRequests getNewRequests()
        {
            NewRequests outRequests = new NewRequests();
            var requests = _unitOfWork.requests.GetNewRequests();
            foreach (var request in requests)
                outRequests.Records.Add(_dataTransferService.NewRequestTransfer(request));
            return outRequests;
        }
    }
}
