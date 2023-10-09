using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Protos;
using ChariswallServices.ServerChannels;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;

namespace ChariswallServices.Services.DataSourceServices
{
    public class RequestTService : IRequestTService
    {
        IUnitOfWork _unitOfWork;
        IHelperServerChannel _channel;
        ICurrencyService _cservice;
        public RequestTService(IUnitOfWork unitOfWork, IHelperServerChannel channel, ICurrencyService cservice)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
            _cservice = cservice;
        }
        public List<RequestActive> NimaRequestsActiveTransfer(List<RequestRecord> requests)
        {
            var requestActives = new List<RequestActive>();

            foreach (var request in requests)
            {
                var country = _unitOfWork.countries.GetCountry(request.Country);
                var requestType = _unitOfWork.requestTypes.GetRequestType(request.RequestType);
                var rateType = _unitOfWork.rateTypes.GetRateType(request.AmountType);
                var registererType = _unitOfWork.registererTypes.GetRegistererType(request.Rigister);

                requestActives.Add(new RequestActive
                {
                    RequestCode = request.RequestCode,
                    RegisterOrderCode = request.RegisterOrderCode,
                    Currency = _cservice.GetSymbol(request.CurrencyName),
                    Amount = (decimal)request.Amount,
                    Country = country,
                    PaymentExpireDate = string.IsNullOrEmpty(request.PaymentExpireTime) ? null : DateTime.Parse(request.PaymentExpireTime),
                    ExpireDate = string.IsNullOrEmpty(request.ExpireTime) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = request.ExpireTime }).Date),
                    RequestType = requestType,
                    RateType = rateType,
                    RequestDate = string.IsNullOrEmpty(request.OrderTime) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = request.OrderTime }).Date),
                    RegistererType = registererType,
                    DetailRead = false,
                    ServerDateTimeRead = DateTime.Now
                });
            }
            return requestActives;
        }

        public Request RequestTransfer(RequestRecord record)
        {
            var country = _unitOfWork.countries.GetCountry(record.Country);
            var requestType = _unitOfWork.requestTypes.GetRequestType(record.RequestType);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.AmountType);
            var registererType = _unitOfWork.registererTypes.GetRegistererType(record.Rigister);

            return new Request
            {
                RequestCode = record.RequestCode,
                RegisterOrderCode = record.RegisterOrderCode,
                Currency = _cservice.GetSymbol(record.CurrencyName),
                Amount = (decimal)record.Amount,
                Country = country,
                PaymentExpireDate = string.IsNullOrEmpty(record.PaymentExpireTime) ? null : DateTime.Parse(record.PaymentExpireTime),
                ExpireDate = string.IsNullOrEmpty(record.ExpireTime) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.ExpireTime }).Date),
                RequestType = requestType,
                RateType = rateType,
                RequestDate = string.IsNullOrEmpty(record.OrderTime) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.OrderTime }).Date),
                RegistererType = registererType,
                DetailRead = false,
                ServerDateTimeRead = DateTime.Now
            };
        }

        public RequestLog RequestLogTransfer(RequestRecord record)
        {
            var country = _unitOfWork.countries.GetCountry(record.Country);
            var requestType = _unitOfWork.requestTypes.GetRequestType(record.RequestType);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.AmountType);
            var registererType = _unitOfWork.registererTypes.GetRegistererType(record.Rigister);

            return new RequestLog
            {
                RequestCode = record.RequestCode,
                RegisterOrderCode = record.RegisterOrderCode,
                Currency = _cservice.GetSymbol(record.CurrencyName),
                Amount = (decimal)record.Amount,
                Country = country,
                PaymentExpireDate = string.IsNullOrEmpty(record.PaymentExpireTime) ? null : DateTime.Parse(record.PaymentExpireTime),
                ExpireDate = string.IsNullOrEmpty(record.ExpireTime) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.ExpireTime }).Date),
                RequestType = requestType,
                RateType = rateType,
                RequestDate = string.IsNullOrEmpty(record.OrderTime) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.OrderTime }).Date),
                RegistererType = registererType,
                ServerDateTime = DateTime.Now
            };
        }

        public bool CompareRequestLog(RequestRecord record, RequestLog log)
        {
            var country = _unitOfWork.countries.GetCountry(record.Country);
            var requestType = _unitOfWork.requestTypes.GetRequestType(record.RequestType);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.AmountType);
            var registererType = _unitOfWork.registererTypes.GetRegistererType(record.Rigister);
            DateTime? payExpireDate = string.IsNullOrEmpty(record.PaymentExpireTime) ? null : DateTime.Parse(record.PaymentExpireTime);
            DateTime? expireDate = string.IsNullOrEmpty(record.ExpireTime) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.ExpireTime }).Date);
            DateTime? orderDate = string.IsNullOrEmpty(record.OrderTime) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.OrderTime }).Date);
            var curr = _cservice.GetSymbol(record.CurrencyName);

            if (record.RegisterOrderCode != log.RegisterOrderCode)
                return false;
            if (curr != log.Currency)
                return false;
            if (country != log.Country)
                return false;
            if (payExpireDate != log.PaymentExpireDate)
                return false;
            if (expireDate != log.ExpireDate)
                return false;
            if (requestType != log.RequestType)
                return false;
            if (rateType != log.RateType)
                return false;
            if (orderDate != log.RequestDate)
                return false;
            if (registererType != log.RegistererType)
                return false;
            if (record.Amount != (double)log.Amount)
                return false;

            return true;
        }

        public void RequestFill(RequestRecord record, ref Request request)
        {
            var country = _unitOfWork.countries.GetCountry(record.Country);
            var requestType = _unitOfWork.requestTypes.GetRequestType(record.RequestType);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.AmountType);
            var registererType = _unitOfWork.registererTypes.GetRegistererType(record.Rigister);

            request.RegisterOrderCode = record.RegisterOrderCode;
            request.Currency = _cservice.GetSymbol(record.CurrencyName);
            request.Amount = (decimal)record.Amount;
            request.Country = country;
            request.PaymentExpireDate = string.IsNullOrEmpty(record.PaymentExpireTime) ? null : DateTime.Parse(record.PaymentExpireTime);
            request.ExpireDate = string.IsNullOrEmpty(record.ExpireTime) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.ExpireTime }).Date);
            request.RequestType = requestType;
            request.RateType = rateType;
            request.RequestDate = string.IsNullOrEmpty(record.OrderTime) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.OrderTime }).Date);
            request.RegistererType = registererType;
        }

        public bool CompareRequestDetailLog(RequestDetailRecord record, RequestLog log)
        {
            var ctype = _unitOfWork.customerTypes.GetCType(record.CustomerType);
            DateTime? registerDate = string.IsNullOrEmpty(record.RegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RegistrationDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(record.Company, record.NationalId, ctype, registerDate, record.RegistrationNumber, record.FirstName, record.LastName);
            var curr = _cservice.GetSymbol(record.CurrencyName);
            var requestType = _unitOfWork.requestTypes.GetRequestType(record.RequestType);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.CurrencyRateType);
            var country = _unitOfWork.countries.GetCountry(record.DestinationCountry);
            DateTime? payExpireDate = string.IsNullOrEmpty(record.PaymentExpireDate) ? null : DateTime.Parse(record.PaymentExpireDate);
            DateTime? createDate = string.IsNullOrEmpty(record.RequestRegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RequestRegistrationDate }).Date);
            DateTime? validityDate = string.IsNullOrEmpty(record.RequestValidityDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RequestValidityDate }).Date);
            var state = _unitOfWork.offerStates.GetOfferState(record.State);
            var transferType = _unitOfWork.transferTypes.GetTransferType(record.TransferType);
            var contact = _unitOfWork.customerContacts.GetContact(record.FirstName, record.LastName, null, "", "", "", "", customer, ctype);
            var bankbranch = _unitOfWork.bankBranches.GetBranch(record.BankBranch);
            var user = _unitOfWork.customerUsers.GetUser(record.UserName, record.UserMobileNumber, customer, bankbranch);

            if (customer != log.Customer)
                return false;
            if (record.Amount != (double)log.Amount)
                return false;
            if (curr != log.Currency)
                return false;
            if (rateType != log.RateType)
                return false;
            if (country != log.Country)
                return false;
            if (payExpireDate != log.PaymentExpireDate)
                return false;
            if (record.RegisterOrderCode != log.RegisterOrderCode)
                return false;
            if (record.RequestReason != log.RequestReason)
                return false;
            if (createDate != log.RequestDate)
                return false;
            if (requestType != log.RequestType)
                return false;
            if (validityDate != log.RequestValidityDate)
                return false;
            if (state != log.State)
                return false;
            if (transferType != log.TransferType)
                return false;
            if (user != log.CustomerUser)
                return false;
            if (contact != log.CustomerContact)
                return false;

            return true;
        }

        public RequestLog RequestDetailLogTransfer(RequestDetailRecord record)
        {
            var ctype = _unitOfWork.customerTypes.GetCType(record.CustomerType);
            DateTime? registerDate = string.IsNullOrEmpty(record.RegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RegistrationDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(record.Company, record.NationalId, ctype, registerDate, record.RegistrationNumber, record.FirstName, record.LastName);
            var curr = _cservice.GetSymbol(record.CurrencyName);
            var requestType = _unitOfWork.requestTypes.GetRequestType(record.RequestType);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.CurrencyRateType);
            var country = _unitOfWork.countries.GetCountry(record.DestinationCountry);
            DateTime? payExpireDate = string.IsNullOrEmpty(record.PaymentExpireDate) ? null : DateTime.Parse(record.PaymentExpireDate);
            DateTime? createDate = string.IsNullOrEmpty(record.RequestRegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RequestRegistrationDate }).Date);
            DateTime? validityDate = string.IsNullOrEmpty(record.RequestValidityDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RequestValidityDate }).Date);
            var state = _unitOfWork.offerStates.GetOfferState(record.State);
            var transferType = _unitOfWork.transferTypes.GetTransferType(record.TransferType);
            var contact = _unitOfWork.customerContacts.GetContact(record.FirstName, record.LastName, null, "", "", "", "", customer, ctype);
            var bankbranch = _unitOfWork.bankBranches.GetBranch(record.BankBranch);
            var user = _unitOfWork.customerUsers.GetUser(record.UserName, record.UserMobileNumber, customer, bankbranch);
            var registererType = _unitOfWork.registererTypes.GetRegistererType(record.RegistererType);

            var requestLog = new RequestLog
            {
                Amount = (decimal)record.Amount,
                Country = country,
                Currency = curr,
                Customer = customer,
                State = state,
                PaymentExpireDate = payExpireDate,
                RateType = rateType,
                RegisterOrderCode = record.RegisterOrderCode,
                RequestCode = record.RequestCode,
                RequestDate = createDate,
                Isactive = true,
                RequestReason = record.RequestReason,
                RequestType = requestType,
                RequestValidityDate = validityDate,
                TransferType = transferType,
                RegistererType = registererType,
                ExpireDate = validityDate,
                ServerDateTime = DateTime.Now,
                CustomerUser = user,
                CustomerContact = contact
            };

            return requestLog;
        }

        public void RequestDetailFill(RequestDetailRecord record, ref Request request, ref RequestActive requestActive, ref List<ChariswallNewDomain.Models.NimaOffer> offers)
        {
            var ctype = _unitOfWork.customerTypes.GetCType(record.CustomerType);
            DateTime? registerDate = string.IsNullOrEmpty(record.RegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RegistrationDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(record.Company, record.NationalId, ctype, registerDate, record.RegistrationNumber, record.FirstName, record.LastName);
            var curr = _cservice.GetSymbol(record.CurrencyName);
            var requestType = _unitOfWork.requestTypes.GetRequestType(record.RequestType);
            var rateType = _unitOfWork.rateTypes.GetRateType(record.CurrencyRateType);
            var country = _unitOfWork.countries.GetCountry(record.DestinationCountry);
            DateTime? payExpireDate = string.IsNullOrEmpty(record.PaymentExpireDate) ? null : DateTime.Parse(record.PaymentExpireDate);
            DateTime? createDate = string.IsNullOrEmpty(record.RequestRegistrationDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RequestRegistrationDate }).Date);
            DateTime? validityDate = string.IsNullOrEmpty(record.RequestValidityDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RequestValidityDate }).Date);
            var state = _unitOfWork.offerStates.GetOfferState(record.State);
            var transferType = _unitOfWork.transferTypes.GetTransferType(record.TransferType);
            var contact = _unitOfWork.customerContacts.GetContact(record.FirstName, record.LastName, null, "", "", "", "", customer, ctype);
            var bankbranch = _unitOfWork.bankBranches.GetBranch(record.BankBranch);
            var user = _unitOfWork.customerUsers.GetUser(record.UserName, record.UserMobileNumber, customer, bankbranch);
            var registererType = _unitOfWork.registererTypes.GetRegistererType(record.RegistererType);

            request.RequestCode = record.RequestCode;
            request.RegisterOrderCode = record.RegisterOrderCode;
            request.Currency = curr;
            request.Amount = (decimal)record.Amount;
            request.Country = country;
            request.PaymentExpireDate = payExpireDate;
            request.ExpireDate = validityDate;
            request.RequestType = requestType;
            request.RateType = rateType;
            request.RegistererType = registererType;
            request.ServerDateTimeDetailRead = DateTime.Now;
            request.State = state;
            request.RequestDate = createDate;
            request.RequestReason = record.RequestReason;
            request.TransferType = transferType;
            request.Customer = customer;
            request.DetailRead = true;
            request.CustomerUser = user;
            request.CustomerContact = contact;
            if (requestActive != null)
            {
                requestActive.RequestCode = record.RequestCode;
                requestActive.RegisterOrderCode = record.RegisterOrderCode;
                requestActive.Currency = curr;
                requestActive.Amount = (decimal)record.Amount;
                requestActive.Country = country;
                requestActive.PaymentExpireDate = payExpireDate;
                requestActive.ExpireDate = validityDate;
                requestActive.RequestType = requestType;
                requestActive.RateType = rateType;
                requestActive.RegistererType = registererType;
                requestActive.ServerDateTimeDetailRead = DateTime.Now;
                requestActive.State = state;
                requestActive.RequestDate = createDate;
                requestActive.RequestReason = record.RequestReason;
                requestActive.TransferType = transferType;
                requestActive.Customer = customer;
                requestActive.DetailRead = true;
                requestActive.CustomerUser = user;
                requestActive.CustomerContact = contact;
            }
            foreach (var offer in offers)
            {
                offer.RequestDetailRead = 1;
                offer.RequestStatus = state;
                offer.RequestType = requestType;
                offer.RequestRegisterDate = registerDate;
                offer.RegisterValidityDate = validityDate;
                offer.RegisterCode = record.RegisterOrderCode;
                offer.CustomerTradeType = registererType;
                offer.RequestPaymentDeadline = payExpireDate;
                offer.RequestReason = record.RequestReason;
                offer.DestinationCountry = country;
                offer.Customer = customer;
                offer.CustomerContact = contact;
                offer.CustomerUser = user;
            }
        }
        public RequestOutRecord NewRequestTransfer(Request request)
        {
            return new RequestOutRecord { RequestCode = request.RequestCode };
        }
    }
}
