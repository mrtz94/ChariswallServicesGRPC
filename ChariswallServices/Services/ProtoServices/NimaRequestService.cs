using ChariswallServices.Protos;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;
using Grpc.Core;

namespace ChariswallServices.Services.ProtoServices
{
    public class NimaRequestService : NimaRequest.NimaRequestBase
    {
        IRequestSService _service;
        public NimaRequestService(IRequestSService service)
        {
            _service = service;
        }

        public override Task<CheckOutput> CheckRequest(CodeInput input, ServerCallContext context)
        {
            try
            {
                var res = _service.CheckRequest(input.Code);
                return Task.FromResult(new CheckOutput { Result = res });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CheckOutput { Result = false });
            }
        }

        public override Task<ResultOutputRequest> ProcessRequests(RequestInput input, ServerCallContext context)
        {
            try
            {
                _service.processRequests(input.Requests.ToList());
                return Task.FromResult(new ResultOutputRequest { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputRequest { Result = false });
            }
        }

        public override Task<ResultOutputRequest> ProcessRequestDetail(RequestDetailInput input, ServerCallContext context)
        {
            try
            {
                _service.processRequestDetail(input.Request);
                return Task.FromResult(new ResultOutputRequest { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputRequest { Result = false });
            }
        }
        public override Task<NewRequests> GetNewRequests(GeneralInputRequest input, ServerCallContext context)
        {
            try
            {
                var output = _service.getNewRequests();
                return Task.FromResult(output);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new NewRequests());
            }
        }
    }
}
