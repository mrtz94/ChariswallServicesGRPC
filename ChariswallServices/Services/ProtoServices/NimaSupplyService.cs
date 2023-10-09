using ChariswallServices.Protos;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;
using Grpc.Core;

namespace ChariswallServices.Services.ProtoServices
{
    public class NimaSupplyService : NimaSupply.NimaSupplyBase
    {
        ISupplySService _service;
        public NimaSupplyService(ISupplySService service)
        {
            _service = service;
        }

        public override Task<ResultOutputSupply> ProcessSupplies(SupplyInput input, ServerCallContext context)
        {
            try
            {
                _service.processSupplies(input.Supplies.ToList());
                return Task.FromResult(new ResultOutputSupply { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputSupply { Result = false });
            }
        }

        public override Task<ResultOutputSupply> ProcessSupplyDetail(SupplyDetailInput input, ServerCallContext context)
        {
            try
            {
                _service.processSupplyDetail(input.Supply);
                return Task.FromResult(new ResultOutputSupply { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResultOutputSupply { Result = false });
            }
        }

        public override Task<NewSupplies> GetNewSupplies(GeneralInputSupply input, ServerCallContext context)
        {
            try
            {
                var output = _service.getNewSupplies();
                return Task.FromResult(output);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new NewSupplies());
            }
        }
    }
}
