using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Protos;
using ChariswallServices.ServerChannels;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;

namespace ChariswallServices.Services.DataSourceServices
{
    public class SupplyTService : ISupplyTService
    {
        IUnitOfWork _unitOfWork;
        IHelperServerChannel _channel;
        ICurrencyService _cservice;
        public SupplyTService(IUnitOfWork unitOfWork, IHelperServerChannel channel, ICurrencyService cservice)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
            _cservice = cservice;
        }
        public List<SupplyActive> NimaSuppliesActiveTransfer(List<SupplyRecord> supplies)
        {
            var suppliesActive = new List<SupplyActive>();

            foreach (var supply in supplies)
            {
                var state = _unitOfWork.requestStates.GetRequestState(supply.State);
                var country = _unitOfWork.countries.GetCountry(supply.Country);
                var rateType = _unitOfWork.rateTypes.GetRateType(supply.RateType);

                suppliesActive.Add(new SupplyActive
                {
                    SupplyCode = supply.SellCode,
                    Supplier = supply.SellerName,
                    State = state,
                    Currency = _cservice.GetSymbol(supply.CurrencyName),
                    Amount = (decimal)supply.Amount,
                    Country = country,
                    UnitPrice = (decimal)supply.SellerPrice,
                    UnitRate = (decimal)supply.UnitRate,
                    RateType = rateType,
                    BuyerExpireTime = supply.BuyerExpireTime,
                    BuyerReviewTime = supply.BuyerReviewTime,
                    DetailLink = supply.RefURL,
                    ServerDateTimeRead = DateTime.Now,
                    DetailRead = 0
                });
            }
            return suppliesActive;
        }

        public Supply SupplyTransfer(SupplyRecord record)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            var country = _unitOfWork.countries.GetCountry(record.Country);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);

            return new Supply
            {
                SupplyCode = record.SellCode,
                Supplier = record.SellerName,
                State = state,
                Currency = _cservice.GetSymbol(record.CurrencyName),
                Amount = (decimal)record.Amount,
                Country = country,
                UnitPrice = (decimal)record.SellerPrice,
                UnitRate = (decimal)record.UnitRate,
                RateType = rateType,
                BuyerExpireTime = record.BuyerExpireTime,
                BuyerReviewTime = record.BuyerReviewTime,
                DetailLink = record.RefURL,
                ServerDateTimeRead = DateTime.Now,
                DetailRead = 0
            };
        }

        public SupplyLog SupplyLogTransfer(SupplyRecord record)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            var country = _unitOfWork.countries.GetCountry(record.Country);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);

            return new SupplyLog
            {
                SupplyCode = record.SellCode,
                State = state,
                Currency = _cservice.GetSymbol(record.CurrencyName),
                Amount = (decimal)record.Amount,
                Country = country,
                UnitPrice = (decimal)record.SellerPrice,
                UnitRate = (decimal)record.UnitRate,
                RateType = rateType,
                BuyerExpireTime = record.BuyerExpireTime,
                BuyerReviewTime = record.BuyerReviewTime,
                DetailLink = record.RefURL,
                ServerDateTime = DateTime.Now,
            };
        }

        public bool CompareSupplyLog(SupplyRecord record, SupplyLog log)
        {

            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            var country = _unitOfWork.countries.GetCountry(record.Country);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);
            var curr = _cservice.GetSymbol(record.CurrencyName);

            if (state != log.State)
                return false;
            if (curr != log.Currency)
                return false;
            if (record.Amount != (double)log.Amount)
                return false;
            if (record.SellerPrice != (double)log.UnitPrice)
                return false;
            if (record.UnitRate != (double)log.UnitRate)
                return false;
            if (rateType != log.RateType)
                return false;
            if (country != log.Country)
                return false;
            if (record.BuyerExpireTime != log.BuyerExpireTime)
                return false;
            if (record.BuyerReviewTime != log.BuyerReviewTime)
                return false;

            return true;
        }

        public void SupplyFill(SupplyRecord record, ref Supply supply)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            var country = _unitOfWork.countries.GetCountry(record.Country);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.RateType);

            supply.SupplyCode = record.SellCode;
            supply.State = state;
            supply.Currency = _cservice.GetSymbol(record.CurrencyName);
            supply.Amount = (decimal)record.Amount;
            supply.Country = country;
            supply.UnitPrice = (decimal)record.SellerPrice;
            supply.UnitRate = (decimal)record.UnitRate;
            supply.RateType = rateType;
            supply.BuyerExpireTime = record.BuyerExpireTime;
            supply.BuyerReviewTime = record.BuyerReviewTime;
            supply.DetailLink = record.RefURL;
        }

        public bool CompareSupplyDetailLog(SupplyDetailRecord record, SupplyLog log)
        {
            var ctype = _unitOfWork.customerTypes.GetCType(record.CustomerType);
            DateTime? registerDate = string.IsNullOrEmpty(record.RegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RegistrationDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(record.Company, record.NationalId, ctype, registerDate, record.RegistrationNumber, record.Firstname, record.Lastname);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.CurrencyRateType);
            var exportType = _unitOfWork.exportTypes.GetExportType(record.ExportType);
            var curr = _cservice.GetSymbol(record.CurrencyName);
            var country = _unitOfWork.countries.GetCountry(record.OriginCountry);
            var user = _unitOfWork.customerUsers.GetUser(record.FullNameAgent, record.MobileNumber, customer, null);

            if (record.DemandDeadlineTime != log.BuyerExpireTime && !(string.IsNullOrEmpty(record.DemandDeadlineTime) && string.IsNullOrEmpty(log.BuyerExpireTime)))
                return false;
            if (rateType != log.RateType)
                return false;
            if (record.PaymentCondition != log.PaymentCondition)
                return false;
            if (record.DealRules != log.DealRules)
                return false;
            if (exportType != log.ExportType)
                return false;
            if (curr != log.Currency)
                return false;
            if (record.Amount != (double)log.Amount)
                return false;
            if (country != log.Country)
                return false;
            if (record.CurrencyUnitPrice != log.UnitPrice)
                return false;
            if (record.CurrencyCoefficient != log.UnitRate)
                return false;
            if (record.DemandSelectDeadlineTime != log.BuyerReviewTime && !(string.IsNullOrEmpty(record.DemandSelectDeadlineTime) && string.IsNullOrEmpty(log.BuyerReviewTime)))
                return false;
            if (customer != log.Customer)
                return false;
            if (user != log.CustomerUser)
                return false;

            return true;
        }

        public SupplyLog SupplyDetailLogTransfer(SupplyDetailRecord record)
        {
            var ctype = _unitOfWork.customerTypes.GetCType(record.CustomerType);
            DateTime? registerDate = string.IsNullOrEmpty(record.RegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RegistrationDate }).Date);
            DateTime? SupplyRegisterDate = string.IsNullOrEmpty(record.SupplyRegisterDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.SupplyRegisterDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(record.Company, record.NationalId, ctype, registerDate, record.RegistrationNumber, record.Firstname, record.Lastname);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.CurrencyRateType);
            var exportType = _unitOfWork.exportTypes.GetExportType(record.ExportType);
            var curr = _cservice.GetSymbol(record.CurrencyName);
            var country = _unitOfWork.countries.GetCountry(record.OriginCountry);
            var user = _unitOfWork.customerUsers.GetUser(record.FullNameAgent, record.MobileNumber, customer, null);

            return new SupplyLog
            {
                SupplyCode = record.SupplyCode,
                Customer = customer,
                CustomerUser = user,
                Currency = curr,
                Amount = (decimal)record.Amount,
                Country = country,
                UnitPrice = record.CurrencyUnitPrice,
                UnitRate = record.CurrencyCoefficient,
                BuyerExpireTime = record.DemandDeadlineTime,
                BuyerReviewTime = record.DemandSelectDeadlineTime,
                SupplyRegisterDateTime = SupplyRegisterDate,
                PaymentCondition = record.PaymentCondition,
                DealRules = record.DealRules,
                ExportType = exportType,
                ServerDateTime = DateTime.Now,
                RateType = rateType
            };
        }

        public void SupplyDetailFill(SupplyDetailRecord record, ref Supply supply, ref SupplyActive supplyActive, ref List<ChariswallNewDomain.Models.NimaDeal> deals)
        {
            var ctype = _unitOfWork.customerTypes.GetCType(record.CustomerType);
            DateTime? registerDate = string.IsNullOrEmpty(record.RegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RegistrationDate }).Date);
            DateTime? SupplyRegisterDate = string.IsNullOrEmpty(record.SupplyRegisterDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.SupplyRegisterDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(record.Company, record.NationalId, ctype, registerDate, record.RegistrationNumber, record.Firstname, record.Lastname);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.CurrencyRateType);
            var exportType = _unitOfWork.exportTypes.GetExportType(record.ExportType);
            var curr = _cservice.GetSymbol(record.CurrencyName);
            var country = _unitOfWork.countries.GetCountry(record.OriginCountry);
            var user = _unitOfWork.customerUsers.GetUser(record.FullNameAgent, record.MobileNumber, customer, null);

            supply.Customer = customer;
            supply.CustomerUser = user;
            supply.Currency = curr;
            supply.Amount = (decimal)record.Amount;
            supply.Country = country;
            supply.UnitPrice = record.CurrencyUnitPrice;
            supply.UnitRate = record.CurrencyCoefficient;
            supply.BuyerExpireTime = record.DemandDeadlineTime;
            supply.BuyerReviewTime = record.DemandSelectDeadlineTime;
            supply.SupplyRegisterDateTime = SupplyRegisterDate;
            supply.PaymentCondition = record.PaymentCondition;
            supply.DealRules = record.DealRules;
            supply.ExportType = exportType;
            supply.RateType = !string.IsNullOrWhiteSpace(record.CurrencyRateType) ? rateType : supply.RateType;
            supply.ServerDateTimeDetailRead = DateTime.Now;
            supply.DetailRead = 1;
            if (supplyActive != null)
            {
                supplyActive.Customer = customer;
                supplyActive.CustomerUser = user;
                supplyActive.Currency = curr;
                supplyActive.Amount = (decimal)record.Amount;
                supplyActive.Country = country;
                supplyActive.UnitPrice = record.CurrencyUnitPrice;
                supplyActive.UnitRate = record.CurrencyCoefficient;
                supplyActive.BuyerExpireTime = record.DemandDeadlineTime;
                supplyActive.BuyerReviewTime = record.DemandSelectDeadlineTime;
                supplyActive.SupplyRegisterDateTime = SupplyRegisterDate;
                supplyActive.PaymentCondition = record.PaymentCondition;
                supplyActive.DealRules = record.DealRules;
                supplyActive.ExportType = exportType;
                supplyActive.RateType = rateType;
                supplyActive.ServerDateTimeDetailRead = DateTime.Now;
                supplyActive.DetailRead = 1;
            }
            foreach (var deal in deals)
                deal.SupplyDetailLink = supply.DetailLink;
        }
        public SupplyOutRecord NewSupplyTransfer(Supply supply)
        {
            return new SupplyOutRecord { SupplyCode = supply.SupplyCode, Link = supply.DetailLink };
        }

    }
}
