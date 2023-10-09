using ChariswallServices.Protos;
using ChariswallServices.Services.IDataSourceServices;
using Grpc.Core;

namespace ChariswallServices.Services.ProtoServices
{
    public class XERateService : XERate.XERateBase
    {
        IXERateSService _service;
        public XERateService(IXERateSService service)
        {
            _service = service;
        }

        public override Task<ResultOutputRate> UpdateRates(ratesInput input, ServerCallContext context)
        {
            try
            {
                _service.ProcessRates(input.Records.ToList());
                return Task.FromResult(new ResultOutputRate { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputRate { Result = false });
            }
        }
    }
}
