using ChariswallNewRepositories.IRepository;

namespace ChariswallNewServices.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISanaOrderReasonRepository reasons { get; }
        IActiveSystemRepository activeSystems { get; }
        IBankBranchRepository bankBranches { get; }
        ICountryRepository countries { get; }
        ICreditRepository credits { get; }
        ICurrencyEquivalentRepository currencyEQs { get; }
        ICurrencySymbolRepository symbols { get; }
        ICustomerRepresentativeRepository customerContacts { get; }
        ICustomerTradeTypeRepository customerTradeTypes { get; }
        ICustomerTypeRepository customerTypes { get; }
        ICustomerUserRepository customerUsers { get; }
        IDealTypeRepository dealTypes { get; }
        IDestinationBankRepository destinationBanks { get; }
        IEndDurationRepository endDurations { get; }
        IExchangeBankAccountRepository ExchangeBankAccounts { get; }
        IExchangeCustomerRepository customers { get; }
        IExpertLevelRepository levels { get; }
        IExportTypeRepository exportTypes { get; }
        IIndustryRepository industries { get; }
        INimaBankAccountRepository nimaBankAccounts { get; }
        INimaBankRepository NimaBanks { get; }
        INimaDealActiveRepository dealsActive { get; }
        INimaDealLogRepository dealsLog { get; }
        INimaDealPaymentRepository dealPayments { get; }
        INimaDealRepository deals { get; }
        INimaOfferActiveRepository offersActive { get; }
        INimaOfferLogRepository offersLog { get; }
        INimaOfferPaymentRepository offerPayments { get; }
        INimaOfferPoRepository offerPOs { get; }
        INimaOfferRepository offers { get; }
        INimaOfferStateRepository offerStates { get; }
        IPaymentToolRepository payTools { get; }
        INimaPaymentStatusRepository payStates { get; }
        INimaRateTypeRepository rateTypes { get; }
        INimaRequestStateRepository requestStates { get; }
        INimaRequestTypeRepository requestTypes { get; }
        INimaTransferTypeRepository transferTypes { get; }
        IRegistererTypeRepository registererTypes { get; }
        IRequestActiveRepository requestsActive { get; }
        IRequestLogRepository requestsLog { get; }
        IRequestRepository requests { get; }
        IRialPaymentMethodRepository rialPayMethods { get; }
        ISanaActionRepository sanaActions { get; }
        ISanaHeadingRepository sanaHeadings { get; }
        ISanaOrderLogRepository sanaOrdersLog { get; }
        ISanaOrderRepository sanaOrders { get; }
        IPaymentMethodRepository payMethods { get; }
        ISanaPaymentRepository sanaPays { get; }
        ISanaSourceRepository sanaSources { get; }
        ISanaStateRepository sanaStates { get; }
        ISupplyActiveRepository suppliesActive { get; }
        ISupplyLogRepository suppliesLog { get; }
        ISupplyRepository supplies { get; }
        ISystemConfigRepository systemConfigs { get; }
        ITrustyRepository trusties { get; }
        IUserActionRepository userActions { get; }
        IXerateRepository rates { get; }
        IValidityCheckRepository validityChecks { get; }
        int Complete(); 
    }
}
