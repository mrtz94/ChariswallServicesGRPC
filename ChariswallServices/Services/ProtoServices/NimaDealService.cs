using ChariswallServices.Protos;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;
using Grpc.Core;

namespace ChariswallServices.Services.ProtoServices
{
    public class NimaDealService : NimaDeal.NimaDealBase
    {
        IDealSService _service;
        public NimaDealService(IDealSService service)
        {
            _service = service;
        }
        public override Task<ResultOutputDeal> ProcessDemands(DemandInput input, ServerCallContext context)
        {
            try
            {
                _service.processDemands(input.Demands.ToList());
                return Task.FromResult(new ResultOutputDeal { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputDeal { Result = false });
            }
        }

        public override Task<ResultOutputDeal> ProcessDeals(DealInput input, ServerCallContext context)
        {
            try
            {
                _service.processDeals(input.Deals.ToList());
                return Task.FromResult(new ResultOutputDeal { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputDeal { Result = false });
            }
        }

        public override Task<ResultOutputDeal> ProcessDemandDetail(DemandDetailInput input, ServerCallContext context)
        {
            try
            {
                _service.processDemandDetail(input.Demand);
                return Task.FromResult(new ResultOutputDeal { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputDeal { Result = false });
            }
        }

        public override Task<ResultOutputDeal> ProcessDealDetail(DealDetailInput input, ServerCallContext context)
        {
            try
            {
                _service.processsDealDetail(input.Deal);
                return Task.FromResult(new ResultOutputDeal { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputDeal { Result = false });
            }
        }
        public override Task<ResultOutputDeal> ProcessDealPayments(NimaPaymentInputDeal input, ServerCallContext context)
        {
            try
            {
                _service.ProcessNimaDealPayments(input.Pays.ToList(), input.Code);
                return Task.FromResult(new ResultOutputDeal { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputDeal { Result = false });
            }
        }
        public override Task<NewDemands> GetNewDemands(GeneralInputDeal input, ServerCallContext context)
        {
            try
            {
                var output = _service.getNewDemands();
                return Task.FromResult(output);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new NewDemands());
            }
        }

        public override Task<NewDeals> GetNewDeals(GeneralInputDeal input, ServerCallContext context)
        {
            try
            {
                var output = _service.getNewDeals();
                return Task.FromResult(output);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new NewDeals());
            }
        }
        public override Task<NewDeals> GetUnfinishedDeals(GeneralInputDeal input, ServerCallContext context)
        {
            try
            {
                var output = _service.getUnfinishedDeals();
                return Task.FromResult(output);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new NewDeals());
            }
        }

        public override Task<LastDateOutputDeal> GetBuysLastDate(GeneralInputDeal input, ServerCallContext context)
        {
            try
            {
                var output = _service.buysLastDate();
                return Task.FromResult(new LastDateOutputDeal { LastDate = output });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new LastDateOutputDeal());
            }
        }
    }
}
