using ChariswallNewDomain.Context;
using ChariswallNewRepositories.IRepository;
using ChariswallNewRepositories.Repository;

namespace ChariswallNewServices.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChariswallDemoDbContext _context;
        public UnitOfWork(ChariswallDemoDbContext context)
        {
            _context = context;

            reasons = new SanaOrderReasonRepository(_context);
            activeSystems = new ActiveSystemRepository(_context);
            bankBranches = new BankBranchRepository(_context);
            countries = new CountryRepository(_context);
            credits = new CreditRepository(_context);
            currencyEQs = new CurrencyEquivalentRepository(_context);
            symbols = new CurrencySymbolRepository(_context);
            customerContacts = new CustomerRepresentativeRepository(_context);
            customerTradeTypes = new CustomerTradeTypeRepository(_context);
            customerTypes = new CustomerTypeRepository(_context);
            customerUsers = new CustomerUserRepository(_context);
            dealTypes = new DealTypeRepository(_context);
            destinationBanks = new DestinationBankRepository(_context);
            endDurations = new EndDurationRepository(_context);
            ExchangeBankAccounts = new ExchangeBankAccountRepository(_context);
            customers = new ExchangeCustomerRepository(_context);
            levels = new ExpertLevelRepository(_context);
            exportTypes = new ExportTypeRepository(_context);
            industries = new IndustryRepository(_context);
            nimaBankAccounts = new NimaBankAccountRepository(_context);
            NimaBanks = new NimaBankRepository(_context);
            dealsActive = new NimaDealActiveRepository(_context);
            dealsLog = new NimaDealLogRepository(_context);
            dealPayments = new NimaDealPaymentRepository(_context);
            deals = new NimaDealRepository(_context);
            offersActive = new NimaOfferActiveRepository(_context);
            offersLog = new NimaOfferLogRepository(_context);
            offerPayments = new NimaOfferPaymentRepository(_context);
            offerPOs = new NimaOfferPoRepository(_context);
            offers = new NimaOfferRepository(_context);
            offerStates = new NimaOfferStateRepository(_context);
            payTools = new PaymentToolRepository(_context);
            payStates = new NimaPaymentStatusRepository(_context);
            rateTypes = new NimaRateTypeRepository(_context);
            requestStates = new NimaRequestStateRepository(_context);
            requestTypes = new NimaRequestTypeRepository(_context);
            transferTypes = new NimaTransferTypeRepository(_context);
            registererTypes = new RegistererTypeRepository(_context);
            requestsActive = new RequestActiveRepository(_context);
            requestsLog = new RequestLogRepository(_context);
            requests = new RequestRepository(_context);
            rialPayMethods = new RialPaymentMethodRepository(_context);
            sanaActions = new SanaActionRepository(_context);
            sanaHeadings = new SanaHeadingRepository(_context);
            sanaOrdersLog = new SanaOrderLogRepository(_context);
            sanaOrders = new SanaOrderRepository(_context);
            payMethods = new PaymentMethodRepository(_context);
            sanaPays = new SanaPaymentRepository(_context);
            sanaSources = new SanaSourceRepository(_context);
            sanaStates = new SanaStateRepository(_context);
            suppliesActive = new SupplyActiveRepository(_context);
            suppliesLog = new SupplyLogRepository(_context);
            supplies = new SupplyRepository(_context);
            systemConfigs = new SystemConfigRepository(_context);
            trusties = new TrustyRepository(_context);
            userActions = new UserActionRepository(_context);
            rates = new XerateRepository(_context);
            validityChecks = new ValidityCheckRepository(_context);
        }
        public ISanaOrderReasonRepository reasons { get; }
        public IActiveSystemRepository activeSystems { get; }
        public IBankBranchRepository bankBranches { get; }
        public ICountryRepository countries { get; }
        public ICreditRepository credits { get; }
        public ICurrencyEquivalentRepository currencyEQs { get; }
        public ICurrencySymbolRepository symbols { get; }
        public ICustomerRepresentativeRepository customerContacts { get; }
        public ICustomerTradeTypeRepository customerTradeTypes { get; }
        public ICustomerTypeRepository customerTypes { get; }
        public ICustomerUserRepository customerUsers { get; }
        public IDealTypeRepository dealTypes { get; }
        public IDestinationBankRepository destinationBanks { get; }
        public IEndDurationRepository endDurations { get; }
        public IExchangeBankAccountRepository ExchangeBankAccounts { get; }
        public IExchangeCustomerRepository customers { get; }
        public IExpertLevelRepository levels { get; }
        public IExportTypeRepository exportTypes { get; }
        public IIndustryRepository industries { get; }
        public INimaBankAccountRepository nimaBankAccounts { get; }
        public INimaBankRepository NimaBanks { get; }
        public INimaDealActiveRepository dealsActive { get; }
        public INimaDealLogRepository dealsLog { get; }
        public INimaDealPaymentRepository dealPayments { get; }
        public INimaDealRepository deals { get; }
        public INimaOfferActiveRepository offersActive { get; }
        public INimaOfferLogRepository offersLog { get; }
        public INimaOfferPaymentRepository offerPayments { get; }
        public INimaOfferPoRepository offerPOs { get; }
        public INimaOfferRepository offers { get; }
        public INimaOfferStateRepository offerStates { get; }
        public IPaymentToolRepository payTools { get; }
        public INimaPaymentStatusRepository payStates { get; }
        public INimaRateTypeRepository rateTypes { get; }
        public INimaRequestStateRepository requestStates { get; }
        public INimaRequestTypeRepository requestTypes { get; }
        public INimaTransferTypeRepository transferTypes { get; }
        public IRegistererTypeRepository registererTypes { get; }
        public IRequestActiveRepository requestsActive { get; }
        public IRequestLogRepository requestsLog { get; }
        public IRequestRepository requests { get; }
        public IRialPaymentMethodRepository rialPayMethods { get; }
        public ISanaActionRepository sanaActions { get; }
        public ISanaHeadingRepository sanaHeadings { get; }
        public ISanaOrderLogRepository sanaOrdersLog { get; }
        public ISanaOrderRepository sanaOrders { get; }
        public IPaymentMethodRepository payMethods { get; }
        public ISanaPaymentRepository sanaPays { get; }
        public ISanaSourceRepository sanaSources { get; }
        public ISanaStateRepository sanaStates { get; }
        public ISupplyActiveRepository suppliesActive { get; }
        public ISupplyLogRepository suppliesLog { get; }
        public ISupplyRepository supplies { get; }
        public ISystemConfigRepository systemConfigs { get; }
        public ITrustyRepository trusties { get; }
        public IUserActionRepository userActions { get; }
        public IXerateRepository rates { get; }
        public IValidityCheckRepository validityChecks { get; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
