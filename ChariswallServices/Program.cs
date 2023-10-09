using ChariswallNewDomain.Context;
using ChariswallNewRepositories.IRepository;
using ChariswallNewRepositories.Repository;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices;
using ChariswallServices.Protos;
using ChariswallServices.ServerChannels;
using ChariswallServices.Services;
using ChariswallServices.Services.DataServices;
using ChariswallServices.Services.DataSourceServices;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;
using ChariswallServices.Services.ProtoServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid = 2099682

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<ChariswallDemoDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("ChariswallDB")); });

builder.Services.AddGrpc();

builder.Services.AddScoped<ISanaOrderSService, SanaOrderSService>();
builder.Services.AddScoped<IRequestSService, RequestSService>();
builder.Services.AddScoped<IOfferSService, OfferSService>();
builder.Services.AddScoped<IDealSService, DealSService>();
builder.Services.AddScoped<ISupplySService, SupplySService>();
builder.Services.AddScoped<IXERateSService, XERateSService>();

builder.Services.AddScoped<ISanaOrderTService, SanaOrderTService>();
builder.Services.AddScoped<IRequestTService, RequestTService>();
builder.Services.AddScoped<IOfferTService, OfferTService>();
builder.Services.AddScoped<IDealTService, DealTService>();
builder.Services.AddScoped<ISupplyTService, SupplyTService>();

builder.Services.AddScoped<ICurrencyService, CurrencyService>();

builder.Services.AddScoped<IHelperServerChannel, HelperServerChannel>();

builder.Services.AddScoped<SanaTransaction.SanaTransactionBase, SanaTransactionService>();
builder.Services.AddScoped<NimaRequest.NimaRequestBase, NimaRequestService>();
builder.Services.AddScoped<NimaOffer.NimaOfferBase, NimaOfferService>();
builder.Services.AddScoped<NimaDeal.NimaDealBase, NimaDealService>();
builder.Services.AddScoped<NimaSupply.NimaSupplyBase, NimaSupplyService>();
builder.Services.AddScoped<XERate.XERateBase, XERateService>();

builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(ChariswallRepository<>));
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(ChariswallRepository<>));

builder.Services.AddScoped<IActiveSystemRepository, ActiveSystemRepository>();
builder.Services.AddScoped<IBankBranchRepository, BankBranchRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICreditRepository, CreditRepository>();
builder.Services.AddScoped<ICurrencyEquivalentRepository, CurrencyEquivalentRepository>();
builder.Services.AddScoped<ICurrencySymbolRepository, CurrencySymbolRepository>();
builder.Services.AddScoped<ICustomerRepresentativeRepository, CustomerRepresentativeRepository>();
builder.Services.AddScoped<ICustomerTradeTypeRepository, CustomerTradeTypeRepository>();
builder.Services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
builder.Services.AddScoped<ICustomerUserRepository, CustomerUserRepository>();
builder.Services.AddScoped<IDealTypeRepository, DealTypeRepository>();
builder.Services.AddScoped<IDestinationBankRepository, DestinationBankRepository>();
builder.Services.AddScoped<IEndDurationRepository, EndDurationRepository>();
builder.Services.AddScoped<IExchangeBankAccountRepository, ExchangeBankAccountRepository>();
builder.Services.AddScoped<IExchangeCustomerRepository, ExchangeCustomerRepository>();
builder.Services.AddScoped<IExpertLevelRepository, ExpertLevelRepository>();
builder.Services.AddScoped<IExportTypeRepository, ExportTypeRepository>();
builder.Services.AddScoped<IIndustryRepository, IndustryRepository>();
builder.Services.AddScoped<INimaBankAccountRepository, NimaBankAccountRepository>();
builder.Services.AddScoped<INimaBankRepository, NimaBankRepository>();
builder.Services.AddScoped<INimaDealActiveRepository, NimaDealActiveRepository>();
builder.Services.AddScoped<INimaDealLogRepository, NimaDealLogRepository>();
builder.Services.AddScoped<INimaDealPaymentRepository, NimaDealPaymentRepository>();
builder.Services.AddScoped<INimaDealRepository, NimaDealRepository>();
builder.Services.AddScoped<INimaOfferActiveRepository, NimaOfferActiveRepository>();
builder.Services.AddScoped<INimaOfferLogRepository, NimaOfferLogRepository>();
builder.Services.AddScoped<INimaOfferPaymentRepository, NimaOfferPaymentRepository>();
builder.Services.AddScoped<INimaOfferPoRepository, NimaOfferPoRepository>();
builder.Services.AddScoped<INimaOfferRepository, NimaOfferRepository>();
builder.Services.AddScoped<INimaOfferStateRepository, NimaOfferStateRepository>();
builder.Services.AddScoped<IPaymentToolRepository, PaymentToolRepository>();
builder.Services.AddScoped<INimaPaymentStatusRepository, NimaPaymentStatusRepository>();
builder.Services.AddScoped<INimaRateTypeRepository, NimaRateTypeRepository>();
builder.Services.AddScoped<INimaRequestStateRepository, NimaRequestStateRepository>();
builder.Services.AddScoped<INimaRequestTypeRepository, NimaRequestTypeRepository>();
builder.Services.AddScoped<INimaTransferTypeRepository, NimaTransferTypeRepository>();
builder.Services.AddScoped<IRegistererTypeRepository, RegistererTypeRepository>();
builder.Services.AddScoped<IRequestActiveRepository, RequestActiveRepository>();
builder.Services.AddScoped<IRequestLogRepository, RequestLogRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRialPaymentMethodRepository, RialPaymentMethodRepository>();
builder.Services.AddScoped<ISanaActionRepository, SanaActionRepository>();
builder.Services.AddScoped<ISanaHeadingRepository, SanaHeadingRepository>();
builder.Services.AddScoped<ISanaOrderLogRepository, SanaOrderLogRepository>();
builder.Services.AddScoped<ISanaOrderRepository, SanaOrderRepository>();
builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
builder.Services.AddScoped<ISanaPaymentRepository, SanaPaymentRepository>();
builder.Services.AddScoped<ISanaSourceRepository, SanaSourceRepository>();
builder.Services.AddScoped<ISanaStateRepository, SanaStateRepository>();
builder.Services.AddScoped<ISupplyActiveRepository, SupplyActiveRepository>();
builder.Services.AddScoped<ISupplyLogRepository, SupplyLogRepository>();
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();
builder.Services.AddScoped<ISystemConfigRepository, SystemConfigRepository>();
builder.Services.AddScoped<ITrustyRepository, TrustyRepository>();
builder.Services.AddScoped<IUserActionRepository, UserActionRepository>();
builder.Services.AddScoped<IXerateRepository, XerateRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<SanaTransactionService>();
app.MapGrpcService<NimaRequestService>();
app.MapGrpcService<NimaDealService>();
app.MapGrpcService<NimaOfferService>();
app.MapGrpcService<NimaSupplyService>();
app.MapGrpcService<XERateService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid = 2086909");

app.Run();
