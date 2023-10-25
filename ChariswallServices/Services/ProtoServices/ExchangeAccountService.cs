using ChariswallServices.Protos;
using ChariswallServices.Services.IDataSourceServices;
using Grpc.Core;

namespace ChariswallServices.Services.ProtoServices
{
    public class ExchangeAccountService : ExchangeAccount.ExchangeAccountBase
    {
        IExchangeAccountSService _service;
        public ExchangeAccountService(IExchangeAccountSService service)
        {
            _service = service;
        }
        public override Task<accountList> GetAccounts(GeneralInputAcc input, ServerCallContext context)
        {
            try
            {
                var accs = _service.GetAccounts();
                return Task.FromResult(accs);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new accountList());
            }
        }
        public override Task<accountList> GetActive(GeneralInputAcc input, ServerCallContext context)
        {
            try
            {
                var accs = _service.GetActive();
                return Task.FromResult(accs);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new accountList());
            }
        }
        public override Task<GeneralOutput> AddAccount(account input, ServerCallContext context)
        {
            try
            {
                _service.AddAccount(input);
                return Task.FromResult(new GeneralOutput { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new GeneralOutput { Result = false });
            }
        }
        public override Task<GeneralOutput> DisableAccount(GeneralInputAcc input, ServerCallContext context)
        {
            try
            {
                _service.DisableAccount(input.Input);
                return Task.FromResult(new GeneralOutput { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new GeneralOutput { Result = false });
            }
        }
        public override Task<GeneralOutput> SetDefault(GeneralInputAcc input, ServerCallContext context)
        {
            try
            {
                _service.SetDefault(input.Input);
                return Task.FromResult(new GeneralOutput { Result = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new GeneralOutput { Result = false });
            }
        }
    }
}
