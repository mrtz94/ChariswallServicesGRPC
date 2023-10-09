using ChariswallServices.Services.IDataSourceServices;
using Grpc.Core;

namespace ChariswallServices.Services.ProtoServices
{
    public class SanaTransactionService : SanaTransaction.SanaTransactionBase
    {
        ISanaOrderSService _service;
        public SanaTransactionService(ISanaOrderSService service)
        {
            _service = service;
        }

        public override Task<ResultOutput> GetTransaction(TransactionInput input, ServerCallContext context)
        {
            try
            {
                _service.AddOrUpdateTransaction(input);
                return Task.FromResult(new ResultOutput { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutput { Result = false });
            }
        }

        public override Task<ResultOutput> SavePayments(PaymentInput input, ServerCallContext context)
        {
            try
            {
                _service.AddOrUpdateTransactionPayments(input.Payment.ToList(), input.TrackingNumber);
                return Task.FromResult(new ResultOutput { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutput { Result = false });
            }
        }

        public override Task<TNOutput> checkTransaction(TNInput input, ServerCallContext context)
        {
            try
            {
                var link = _service.GetTransaction(input.TrackingNumber);
                return Task.FromResult(new TNOutput { Link = link });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new TNOutput { Link = "" });
            }
        }

    }
}
