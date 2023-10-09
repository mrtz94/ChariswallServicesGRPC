using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Protos;
using ChariswallServices.ServerChannels;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;

namespace ChariswallServices.Services.DataSourceServices
{
    public class DealTService : IDealTService
    {
        IUnitOfWork _unitOfWork;
        IHelperServerChannel _channel;
        ICurrencyService _cservice;
        public DealTService(IUnitOfWork unitOfWork, IHelperServerChannel channel, ICurrencyService cservice)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
            _cservice = cservice;
        }
        //nima demands
        public List<NimaDealActive> NimaDemandsActiveTransfer(List<DemandRecord> demands)
        {
            var demandsActive = new List<NimaDealActive>();

            foreach (var demand in demands)
            {
                var rateType = _unitOfWork.rateTypes.GetRateType(demand.RateType);
                var state = _unitOfWork.offerStates.GetOfferState(demand.BuyerState);

                demandsActive.Add(new NimaDealActive
                {
                    SupplyCode = demand.SellCode,
                    Supplier = demand.SellerName,
                    Currency = _cservice.GetSymbol(demand.CurrencyName),
                    Amount = demand.SellAmount,
                    SupplyRate = demand.BuyerPrice,
                    CurrencyRateFactor = demand.UnitRate,
                    RateType = rateType,
                    DemandCode = demand.DemandCode,
                    Status = state,
                    StatusText = demand.BuyerState,
                    DemandAmount = demand.BuyerAmount,
                    MinAmount = demand.BuyerAmountMin,
                    DemandDetailLink = demand.RefURL,
                    IsDeal = false,
                    DemandDateTime = DateTime.Now,
                    DealDetailRead = 0,
                    ServerDateTimeRead = DateTime.Now,
                    TradeDetailLink = ""
                });
            }
            return demandsActive;
        }

        public ChariswallNewDomain.Models.NimaDeal DemandTransfer(DemandRecord record)
        {
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var state = _unitOfWork.offerStates.GetOfferState(record.BuyerState);

            return new ChariswallNewDomain.Models.NimaDeal
            {
                SupplyCode = record.SellCode,
                Supplier = record.SellerName,
                Currency = _cservice.GetSymbol(record.CurrencyName),
                Amount = record.SellAmount,
                SupplyRate = record.BuyerPrice,
                CurrencyRateFactor = record.UnitRate,
                RateType = rateType,
                DemandCode = record.DemandCode,
                Status = state,
                StatusText = record.BuyerState,
                DemandAmount = record.BuyerAmount,
                MinAmount = record.BuyerAmountMin,
                DemandDetailLink = record.RefURL,
                IsDeal = false,
                DemandDateTime = DateTime.Now,
                DealDetailRead = 0,
                ServerDateTimeRead = DateTime.Now,
                TradeDetailLink = ""
            };
        }

        public NimaDealLog DemandLogTransfer(DemandRecord record)
        {
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var state = _unitOfWork.offerStates.GetOfferState(record.BuyerState);

            return new NimaDealLog
            {
                Currency = _cservice.GetSymbol(record.CurrencyName),
                Amount = record.SellAmount,
                SupplyRate = record.BuyerPrice,
                CurrencyRateFactor = record.UnitRate,
                RateType = rateType,
                DemandCode = record.DemandCode,
                Status = state,
                DemandAmount = record.BuyerAmount,
                MinAmount = record.BuyerAmountMin,
                IsDeal = false,
                ServerDateTimeRead = DateTime.Now,
                TradeDetailLink = "",
            };
        }

        public bool CompareDemandLog(DemandRecord record, NimaDealLog log)
        {

            var state = _unitOfWork.offerStates.GetOfferState(record.BuyerState);

            if (state != log.Status)
                return false;

            return true;
        }

        public void DemandFill(DemandRecord record, ref ChariswallNewDomain.Models.NimaDeal deal)
        {
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var state = _unitOfWork.offerStates.GetOfferState(record.BuyerState);

            deal.Currency = _cservice.GetSymbol(record.CurrencyName);
            deal.Amount = record.SellAmount;
            deal.SupplyRate = record.BuyerPrice;
            deal.CurrencyRateFactor = record.UnitRate;
            deal.RateType = rateType;
            deal.DemandCode = record.DemandCode;
            deal.Status = state;
            deal.DemandAmount = record.BuyerAmount;
            deal.MinAmount = record.BuyerAmountMin;
        }

        public bool CompareDemandDetailLog(DemandDetailRecord record, NimaDealLog log)
        {
            var state = _unitOfWork.offerStates.GetOfferState(record.Status);

            if (state != log.Status)
                return false;

            return true;

        }

        public NimaDealLog DemandDetailLogTransfer(DemandDetailRecord record)
        {
            var country = _unitOfWork.countries.GetCountry(record.DestinationCountry);
            var state = _unitOfWork.offerStates.GetOfferState(record.Status);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var curr = _cservice.GetSymbol(record.CurrencyName);

            return new NimaDealLog
            {
                DemandCode = record.DemandCode,
                DemandAmount = record.AmountMax,
                MinAmount = record.AmountMin,
                Country = country,
                Status = state,
                RialPaymentCondition = record.PaymentTerms,
                SupplyAmount = record.SupplyAmount,
                RateType = rateType,
                DealCondition = record.DealRules,
                SupplyRate = (int)record.SupplierUnitPrice,
                CurrencyRateFactor = record.CurrencyRateFactor,
                Amount = record.SupplyAmount,
                Currency = curr,
                IsDeal = false,
                ServerDateTimeRead = DateTime.Now,
                TradeDetailLink = ""
            };
        }

        public void DemandDetailFill(DemandDetailRecord record, ref ChariswallNewDomain.Models.NimaDeal demand, ref NimaDealActive demandActive, ref Supply? supply)
        {
            var country = _unitOfWork.countries.GetCountry(record.DestinationCountry);
            var state = _unitOfWork.offerStates.GetOfferState(record.Status);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var curr = _cservice.GetSymbol(record.CurrencyName);
            var ctype = _unitOfWork.customerTypes.GetCType(record.CustomerType);
            DateTime? registerDate = string.IsNullOrEmpty(record.CompanyRegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.CompanyRegistrationDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(record.Supplier, record.NationalId, ctype, registerDate, record.CompanyRegistrationNumber, record.Firstname, record.Lastname);
            var user = _unitOfWork.customerUsers.GetUser(record.FullNameAgent, record.MobileNumber, customer, null);

            demand.DemandCode = record.DemandCode;
            demand.DemandAmount = record.AmountMax;
            demand.MinAmount = record.AmountMin;
            demand.Country = country;
            demand.Status = state;
            demand.RialPaymentCondition = record.PaymentTerms;
            demand.SupplyAmount = record.SupplyAmount;
            demand.RateType = rateType;
            demand.DealCondition = record.DealRules;
            demand.SupplyRate = (int)record.SupplierUnitPrice;
            demand.CurrencyRateFactor = record.CurrencyRateFactor;
            demand.Amount = record.SupplyAmount;
            demand.Currency = curr;
            demand.IsDeal = false;
            demand.ServerDateTimeRead = DateTime.Now;
            demand.Supplier = record.Supplier;
            demand.SupplierId = customer;
            demand.SupplierUser = user;
            if (demandActive != null)
            {
                demandActive.DemandCode = record.DemandCode;
                demandActive.DemandAmount = record.AmountMax;
                demandActive.MinAmount = record.AmountMin;
                demandActive.Country = country;
                demandActive.Status = state;
                demandActive.RialPaymentCondition = record.PaymentTerms;
                demandActive.SupplyAmount = record.SupplyAmount;
                demandActive.RateType = rateType;
                demandActive.DealCondition = record.DealRules;
                demandActive.SupplyRate = (int)record.SupplierUnitPrice;
                demandActive.CurrencyRateFactor = record.CurrencyRateFactor;
                demandActive.Amount = record.SupplyAmount;
                demandActive.Currency = curr;
                demandActive.IsDeal = false;
                demandActive.ServerDateTimeRead = DateTime.Now;
                demandActive.Supplier = record.Supplier;
                demandActive.SupplierId = customer;
                demandActive.SupplierUser = user;
            }
            if (supply == null)
            {
                supply = new Supply
                {
                    Amount = (decimal)demand.SupplyAmount,
                    Currency = demand.Currency,
                    Country = demand.Country,
                    Customer = demand.SupplierId,
                    UnitRate = demand.CurrencyRateFactor,
                    ServerDateTimeRead = DateTime.Now,
                    ServerDateTimeDetailRead = DateTime.Now,
                    DetailRead = 1,
                    CustomerUser = demand.SupplierUser,
                    DealRules = demand.DealCondition,
                    ExportType = demand.ExportType,
                    PaymentCondition = demand.RialPaymentCondition,
                    RateType = demand.RateType,
                    Supplier = demand.Supplier,
                    SupplyCode = demand.SupplyCode,
                    SupplyRegisterDateTime = demand.SupplyRegisterDateTime,
                    UnitPrice = demand.SupplyRate
                };
            }
        }

        //nima deals
        public List<NimaDealActive> NimaDealsActiveTransfer(List<DealRecord> deals)
        {
            var dealsActive = new List<NimaDealActive>();

            foreach (var deal in deals)
            {
                var rateType = _unitOfWork.rateTypes.GetRateType(deal.RateType);
                var state = _unitOfWork.requestStates.GetRequestState(deal.State);
                var curr = _cservice.GetSymbol(deal.CurrencyName);

                dealsActive.Add(new NimaDealActive
                {
                    TradeCode = deal.TradeCode,
                    Amount = deal.Amount,
                    StatusText = deal.State,
                    Status = state,
                    SupplyCode = deal.SellCode,
                    Supplier = deal.SellerName,
                    Currency = curr,
                    RateType = rateType,
                    SupplyRate = deal.UnitPrice,
                    CurrencyRateFactor = deal.UnitRate,
                    DemandCode = deal.DemandCode,
                    TradeDetailLink = deal.RefURL,
                    ServerDateTimeRead = DateTime.Now,
                    DealDetailRead = 0,
                    IsDeal = true
                });
            }
            return dealsActive;
        }

        public ChariswallNewDomain.Models.NimaDeal DealTransfer(DealRecord record)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var curr = _cservice.GetSymbol(record.CurrencyName);

            return new ChariswallNewDomain.Models.NimaDeal
            {
                TradeCode = record.TradeCode,
                Amount = record.Amount,
                StatusText = record.State,
                Status = state,
                SupplyCode = record.SellCode,
                Supplier = record.SellerName,
                Currency = curr,
                RateType = rateType,
                SupplyRate = record.UnitPrice,
                CurrencyRateFactor = record.UnitRate,
                DemandCode = record.DemandCode,
                TradeDetailLink = record.RefURL,
                ServerDateTimeRead = DateTime.Now,
                DealDetailRead = 0,
                IsDeal = true
            };
        }

        public NimaDealLog DealLogTransfer(DealRecord record)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var curr = _cservice.GetSymbol(record.CurrencyName);

            return new NimaDealLog
            {
                TradeCode = record.TradeCode,
                Amount = record.Amount,
                Status = state,
                Currency = curr,
                RateType = rateType,
                SupplyRate = record.UnitPrice,
                CurrencyRateFactor = record.UnitRate,
                DemandCode = record.DemandCode,
                TradeDetailLink = record.RefURL,
                ServerDateTimeRead = DateTime.Now,
                IsDeal = true
            };
        }

        public bool CompareDealLog(DealRecord record, NimaDealLog log)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);

            if (state != log.Status)
                return false;
            if (record.RefURL != log.TradeDetailLink)
                return false;

            return true;
        }

        public void DealFill(DealRecord record, ref ChariswallNewDomain.Models.NimaDeal deal)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var curr = _cservice.GetSymbol(record.CurrencyName);

            deal.TradeCode = record.TradeCode;
            deal.Amount = record.Amount;
            deal.StatusText = record.State;
            deal.Status = state;
            deal.SupplyCode = record.SellCode;
            deal.Supplier = record.SellerName;
            deal.Currency = curr;
            deal.RateType = rateType;
            deal.SupplyRate = record.UnitPrice;
            deal.CurrencyRateFactor = record.UnitRate;
            deal.DemandCode = record.DemandCode;
            deal.TradeDetailLink = record.RefURL;
            deal.ServerDateTimeRead = DateTime.Now;
            deal.DealDetailRead = 0;
            deal.IsDeal = true;
        }

        public bool CompareDealDetailLog(DealDetailRecord record, NimaDealLog log)
        {
            var state = _unitOfWork.offerStates.GetOfferState(record.Status);
            DateTime? podate = (string.IsNullOrEmpty(record.TransferenceDate) || record.TransferenceDate.Contains("حواله صادر نشده")) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.TransferenceDate }).Date);

            if (state != log.Status)
                return false;
            if (podate != log.Podate)
                return false;

            return true;
        }

        public NimaDealLog DealDetailLogTransfer(DealDetailRecord record)
        {
            var countryOrigin = _unitOfWork.countries.GetCountry(record.OriginCountry);
            var state = _unitOfWork.offerStates.GetOfferState(record.Status);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var curr = _cservice.GetSymbol(record.CurrencyName);
            var ctype = _unitOfWork.customerTypes.GetCType(record.CustomerType);
            DateTime? registerDate = string.IsNullOrEmpty(record.RegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RegistrationDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(record.Company, record.NationalId, ctype, registerDate, record.RegistrationNumber, record.Firstname, record.Lastname);
            DateTime? podate = (string.IsNullOrEmpty(record.TransferenceDate) || record.TransferenceDate.Contains("حواله صادر نشده")) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.TransferenceDate }).Date);
            var bank = _unitOfWork.NimaBanks.GetBank(record.SupplierBankName);
            var bankAcc = _unitOfWork.nimaBankAccounts.GetBankAcc(record.AccountNumber, bank, record.AccountOwner, record.IBAN, customer);

            return new NimaDealLog
            {
                TradeCode = record.TradeCode,
                Amount = record.DealAmount,
                Status = state,
                Podate = podate,
                RialAmount = record.RialAmount,
                SupplierBankAccount = bankAcc,
                Currency = curr,
                SupplyAmount = record.SupplyAmount,
                CurrencyRateFactor = record.RateFactor,
                RateType = rateType,
                Country = countryOrigin,
                RialPaymentCondition = record.PaymentCondition,
                DealCondition = record.DealRules,
                DemandAmount = record.AmountMax,
                MinAmount = record.AmountMin,
                SupplyRate = record.SupplyUnitPrice,
                ServerDateTimeRead = DateTime.Now,
                TradeDetailLink = ""
            };
        }

        public void DealDetailFill(DealDetailRecord record, ref ChariswallNewDomain.Models.NimaDeal deal, ref NimaDealActive dealActive, ref Supply? supply)
        {
            var country = _unitOfWork.countries.GetCountry(record.DestinationCountry);
            var countryOrigin = _unitOfWork.countries.GetCountry(record.OriginCountry);
            var state = _unitOfWork.offerStates.GetOfferState(record.Status);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var curr = _cservice.GetSymbol(record.CurrencyName);
            var ctype = _unitOfWork.customerTypes.GetCType(record.CustomerType);
            DateTime? registerDate = string.IsNullOrEmpty(record.RegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RegistrationDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(record.Company, record.NationalId, ctype, registerDate, record.RegistrationNumber, record.Firstname, record.Lastname);
            var user = _unitOfWork.customerUsers.GetUser(record.FullNameAgent, record.MobileNumber, customer, null);
            DateTime? podate = (string.IsNullOrEmpty(record.TransferenceDate) || record.TransferenceDate.Contains("حواله صادر نشده")) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.TransferenceDate }).Date);
            var bank = _unitOfWork.NimaBanks.GetBank(record.SupplierBankName);
            var bankAcc = _unitOfWork.nimaBankAccounts.GetBankAcc(record.AccountNumber, bank, record.AccountOwner, record.IBAN, customer);
            DateTime? createDate = string.IsNullOrEmpty(record.CreateDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.CreateDate }).Date);
            var rpm = _unitOfWork.rialPayMethods.GetMethod(record.RialPaymentMethod);
            var destBank = _unitOfWork.destinationBanks.GetBank(record.DestinationBank);

            deal.TradeCode = record.TradeCode;
            deal.Amount = record.DealAmount;
            deal.Status = state;
            deal.StatusText = record.Status;
            deal.SupplyCode = record.SupplyCode;
            deal.Supplier = record.Company;
            deal.SupplierId = customer;
            deal.Currency = curr;
            deal.SupplyRate = record.SupplyUnitPrice;
            deal.CurrencyRateFactor = record.RateFactor;
            deal.Podate = podate;
            deal.SanaTrackingNumber = record.SanaTrackingCode;
            deal.DealDate = createDate;
            deal.RialAmount = record.RialAmount;
            deal.SupplierBankAccount = bankAcc;
            deal.RateType = rateType;
            deal.SupplyAmount = record.SupplyAmount;
            deal.Country = countryOrigin;
            deal.RialPaymentCondition = record.PaymentCondition;
            deal.DealCondition = record.DealRules;
            deal.SupplierUser = user;
            deal.RialPaymentMethod = rpm;
            deal.DemandAmount = record.AmountMax;
            deal.MinAmount = record.AmountMin;
            deal.DealDetailRead = 1;
            deal.ServerDateTimeDealDetail = DateTime.Now;
            deal.SupplyRegisterDateTime = supply?.SupplyRegisterDateTime;
            deal.ExportType = supply?.ExportType;
            deal.DestinationCountry = country;
            deal.DestinationBankAccount = destBank;
            deal.Swiftcode = record.SWIFT;
            deal.OtherCodes = record.OtherCodes;
            deal.CodeType = record.CodeType;
            deal.AccountNumber = record.AccountNumber;
            deal.Iban = record.IBAN;
            deal.AccountOwnerName = record.AccountOwner;
            deal.IsDeal = true;
            deal.DemandRate = record.CurrencyUnitPrice;

            if (dealActive != null)
            {
                dealActive.TradeCode = record.TradeCode;
                dealActive.Amount = record.DealAmount;
                dealActive.Status = state;
                dealActive.StatusText = record.Status;
                dealActive.SupplyCode = record.SupplyCode;
                dealActive.Supplier = record.Company;
                dealActive.SupplierId = customer;
                dealActive.Currency = curr;
                dealActive.SupplyRate = record.SupplyUnitPrice;
                dealActive.CurrencyRateFactor = record.RateFactor;
                dealActive.Podate = podate;
                dealActive.SanaTrackingNumber = record.SanaTrackingCode;
                dealActive.DealDate = createDate;
                dealActive.RialAmount = record.RialAmount;
                dealActive.SupplierBankAccount = bankAcc;
                dealActive.RateType = rateType;
                dealActive.SupplyAmount = record.SupplyAmount;
                dealActive.Country = countryOrigin;
                dealActive.RialPaymentCondition = record.PaymentCondition;
                dealActive.DealCondition = record.DealRules;
                dealActive.SupplierUser = user;
                dealActive.RialPaymentMethod = rpm;
                dealActive.DemandAmount = record.AmountMax;
                dealActive.MinAmount = record.AmountMin;
                dealActive.DealDetailRead = 1;
                dealActive.ServerDateTimeDealDetail = DateTime.Now;
                dealActive.SupplyRegisterDateTime = supply?.SupplyRegisterDateTime;
                dealActive.ExportType = supply?.ExportType;
                dealActive.DestinationCountry = country;
                dealActive.DestinationBankAccount = destBank;
                dealActive.Swiftcode = record.SWIFT;
                dealActive.OtherCodes = record.OtherCodes;
                dealActive.CodeType = record.CodeType;
                dealActive.AccountNumber = record.AccountNumber;
                dealActive.Iban = record.IBAN;
                dealActive.AccountOwnerName = record.AccountOwner;
                dealActive.IsDeal = true;
                dealActive.DemandRate = record.CurrencyUnitPrice;
            }
            if (supply == null)
            {
                supply = new Supply
                {
                    Amount = (decimal)deal.SupplyAmount,
                    Currency = deal.Currency,
                    Country = deal.Country,
                    Customer = deal.SupplierId,
                    UnitRate = deal.CurrencyRateFactor,
                    ServerDateTimeRead = DateTime.Now,
                    ServerDateTimeDetailRead = DateTime.Now,
                    DetailRead = 1,
                    CustomerUser = deal.SupplierUser,
                    DealRules = deal.DealCondition,
                    ExportType = deal.ExportType,
                    PaymentCondition = deal.RialPaymentCondition,
                    RateType = deal.RateType,
                    Supplier = deal.Supplier,
                    SupplyCode = deal.SupplyCode,
                    SupplyRegisterDateTime = deal.SupplyRegisterDateTime,
                    UnitPrice = deal.SupplyRate
                };
            }
        }

        public DealOutRecord NewDealTransfer(ChariswallNewDomain.Models.NimaDeal deal)
        {
            return new DealOutRecord { DealCode = deal.TradeCode ?? 0, Link = deal.TradeDetailLink };
        }

        public DemandOutRecord NewDemandTransfer(ChariswallNewDomain.Models.NimaDeal demand)
        {
            return new DemandOutRecord { DemandCode = demand.DemandCode, Link = demand.DemandDetailLink };
        }

        public NimaDealPayment NimaDealPaymentTransfer(PaymentRecordDeal payment, int TradeCode)
        {
            DateTime date = string.IsNullOrEmpty(payment.PaymentDate) ? new DateTime() : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = payment.PaymentDate }).Date);
            var bank = _unitOfWork.NimaBanks.GetBank(payment.SourceBankName);
            var payMethod = _unitOfWork.payMethods.GetMethod(payment.PaymentType);
            var state = _unitOfWork.payStates.GetPayStatus(payment.PaymentState);

            return new NimaDealPayment
            {
                PaymentId = payment.PaymentCode,
                PaymentDate = date,
                Amount = payment.PaymentAmount,
                SourceBank = bank,
                PaymentMethod = payMethod,
                Description = payment.PaymentDsc,
                State = state,
                TradeCode = TradeCode
            };
        }

    }
}
