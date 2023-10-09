using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Protos;
using ChariswallServices.ServerChannels;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;

namespace ChariswallServices.Services.DataSourceServices
{
    public class OfferTService: IOfferTService
    {
        IUnitOfWork _unitOfWork;
        IHelperServerChannel _channel;
        ICurrencyService _cservice;
        public OfferTService(IUnitOfWork unitOfWork, IHelperServerChannel channel, ICurrencyService cservice)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
            _cservice = cservice;
        }
        public List<NimaOfferActive> NimaOffersActiveTransfer(List<OfferRecord> offers)
        {
            var offersActive = new List<NimaOfferActive>();

            foreach (var offer in offers)
            {
                var state = _unitOfWork.requestStates.GetRequestState(offer.State);
                DateTime expireTime = string.IsNullOrEmpty(offer.ExpireDateTime) ? new DateTime() : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = offer.ExpireDateTime }).Date);
                var curr = _cservice.GetSymbol(offer.CurrencyName);

                offersActive.Add(new NimaOfferActive
                {
                    OfferCode = offer.OfferCode,
                    Amount = offer.Amount,
                    Currency = curr,
                    OfferExpireTime = expireTime,
                    DetailLink = offer.RefURL,
                    RequestCode = offer.RequestCode,
                    Status = state,
                    StatusText = offer.State,
                    CurrencyRate = offer.UnitPrice,
                    RateFactor = offer.UnitRate,
                    ServerDateTimeRead = DateTime.Now,
                    OfferDetailRead = 0
                });
            }
            return offersActive;
        }

        public ChariswallNewDomain.Models.NimaOffer OfferTransfer(OfferRecord record)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            DateTime expireTime = string.IsNullOrEmpty(record.ExpireDateTime) ? new DateTime() : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.ExpireDateTime }).Date);
            var curr = _cservice.GetSymbol(record.CurrencyName);

            return new ChariswallNewDomain.Models.NimaOffer
            {
                OfferCode = record.OfferCode,
                Amount = record.Amount,
                Currency = curr,
                OfferExpireTime = expireTime,
                DetailLink = record.RefURL,
                RequestCode = record.RequestCode,
                Status = state,
                StatusText = record.State,
                CurrencyRate = record.UnitPrice,
                RateFactor = record.UnitRate,
                ServerDateTimeRead = DateTime.Now,
                OfferDetailRead = 0
            };
        }

        public NimaOfferLog OfferLogTransfer(OfferRecord record)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            DateTime expireTime = string.IsNullOrEmpty(record.ExpireDateTime) ? new DateTime() : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.ExpireDateTime }).Date);
            var curr = _cservice.GetSymbol(record.CurrencyName);

            return new NimaOfferLog
            {
                OfferCode = record.OfferCode,
                Amount = record.Amount,
                Currency = curr,
                OfferExpireTime = expireTime,
                Status = state,
                CurrencyRate = record.UnitPrice,
                RateFactor = record.UnitRate,
                LastUpdateTime = DateTime.Now,
            };
        }

        public bool CompareOfferLog(OfferRecord record, NimaOfferLog log)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            DateTime expireTime = string.IsNullOrEmpty(record.ExpireDateTime) ? new DateTime() : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.ExpireDateTime }).Date);

            if (expireTime != log.OfferExpireTime)
                return false;
            if (state != log.Status)
                return false;
            if (record.UnitPrice != log.CurrencyRate)
                return false;

            return true;
        }

        public void OfferFill(OfferRecord record, ref ChariswallNewDomain.Models.NimaOffer offer)
        {
            var state = _unitOfWork.requestStates.GetRequestState(record.State);
            DateTime expireTime = string.IsNullOrEmpty(record.ExpireDateTime) ? new DateTime() : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.ExpireDateTime }).Date);
            var curr = _cservice.GetSymbol(record.CurrencyName);

            offer.OfferCode = record.OfferCode;
            offer.Amount = record.Amount;
            offer.Currency = curr;
            offer.OfferExpireTime = expireTime;
            offer.DetailLink = record.RefURL;
            offer.RequestCode = record.RequestCode;
            offer.Status = state;
            offer.StatusText = record.State;
            offer.CurrencyRate = record.UnitPrice;
            offer.RateFactor = record.UnitRate;
        }

        public bool CompareOfferDetailLog(OfferDetailRecord record, NimaOfferLog log)
        {
            var state = _unitOfWork.offerStates.GetOfferState(record.State);
            DateTime? LastUpdateTime = string.IsNullOrEmpty(record.LastModifiedDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.LastModifiedDate }).Date);

            if (record.CurrencyUnitPrice != log.CurrencyRate)
                return false;
            if (record.CurrencyWage != log.CurrencyWage)
                return false;
            if (record.IRRWage != log.RialWage)
                return false;
            if (LastUpdateTime != log.LastUpdateTime)
                return false;
            if (record.OfferDescription != log.Description)
                return false;
            if (record.TransferDelayTime != log.Podays)
                return false;
            if (state != log.Status)
                return false;

            return true;
        }

        public NimaOfferLog OfferDetailLogTransfer(OfferDetailRecord record, ChariswallNewDomain.Models.NimaOffer offer)
        {
            var curr = _cservice.GetSymbol(record.CurrencyName);
            DateTime expireTime = string.IsNullOrEmpty(record.ExpireDateTime) ? new DateTime(2000, 1, 1) : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.ExpireDateTime }).Date);
            var state = _unitOfWork.offerStates.GetOfferState(record.State);
            DateTime? LastUpdateTime = string.IsNullOrEmpty(record.LastModifiedDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.LastModifiedDate }).Date);

            int? acc = null;
            if (!string.IsNullOrWhiteSpace(record.ExchangeBankAccount) && record.ExchangeBankAccount.Length > 3)
            {
                var shaba = record.ExchangeBankAccount.Split(" : ")[1];
                var bank = record.ExchangeBankAccount.Split(" : ")[0];
                acc = _unitOfWork.ExchangeBankAccounts.GetAccount(bank, shaba);
            }
            return new NimaOfferLog
            {
                OfferCode = record.OfferCode,
                Currency = curr,
                Amount = record.Amount,
                CurrencyRate = record.CurrencyUnitPrice,
                RateFactor = 0,
                OfferExpireTime = expireTime,
                Status = state,
                Podays = record.TransferDelayTime,
                LastUpdateDate = DateTime.Now,
                Description = record.OfferDescription,
                RialWage = record.IRRWage,
                CurrencyWage = record.CurrencyWage,
                RialAmount = record.TotalPrice,
                ExchangeBankAccount = acc,
                SugestedCurrencyRate = offer?.SugestedCurrencyRate,
                SuggestedWage = offer?.SuggestedWage,
                Added250Wage = (record.Amount < 10000),
                Potype = offer?.Potype,
                Trader = offer?.Trader,
                LastUpdateUser = offer?.LastUpdateUser,
                LastUpdateTime = DateTime.Now,
                LastTransferTryTime = offer?.LastTransferTryTime,
                TransferStatus = offer?.TransferStatus,
                LastNimaChangeTime = LastUpdateTime,
                Enabled = true,
                LastAction = offer?.LastAction,
                LastActionStatus = offer?.LastActionStatus,
                Ponumber = offer?.Ponumber,
                ErrorMessage = offer?.ErrorMessage,
                Industry = offer?.Industry,
                ConvertCurrency = offer?.ConvertCurrency,
                OffPercentage = offer?.OffPercentage
            };
        }

        public void OfferDetailFill(OfferDetailRecord record, ref ChariswallNewDomain.Models.NimaOffer offer, ref NimaOfferActive offerActive, ref Request? request)
        {
            var curr = _cservice.GetSymbol(record.CurrencyName);
            DateTime expireTime = string.IsNullOrEmpty(record.ExpireDateTime) ? new DateTime(2000, 1, 1) : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.ExpireDateTime }).Date);
            var state = _unitOfWork.offerStates.GetOfferState(record.State);
            DateTime? LastUpdateTime = string.IsNullOrEmpty(record.LastModifiedDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.LastModifiedDate }).Date);

            int? acc = null;
            if (!string.IsNullOrWhiteSpace(record.ExchangeBankAccount) && record.ExchangeBankAccount.Length > 3)
            {
                var shaba = record.ExchangeBankAccount.Split(" : ")[1];
                var bank = record.ExchangeBankAccount.Split(" : ")[0];
                acc = _unitOfWork.ExchangeBankAccounts.GetAccount(bank, shaba);
            }
            DateTime? RegisterDate = string.IsNullOrEmpty(record.RegisterDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RegisterDate }).Date);
            DateTime? RialPaymentDeadline = string.IsNullOrEmpty(record.RialPaymentDeadline) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = record.RialPaymentDeadline }).Date);
            var country = _unitOfWork.countries.GetCountry(record.DestinationCountry);

            offer.OfferCode = record.OfferCode;
            offer.Currency = curr;
            offer.Amount = record.Amount;
            offer.CurrencyRate = record.CurrencyUnitPrice;
            offer.OfferExpireTime = expireTime;
            offer.RequestCode = record.RequestCode;
            offer.Status = state;
            offer.StatusText = record.State;
            offer.OfferDate = RegisterDate;
            offer.Podays = record.TransferDelayTime;
            offer.LastUpdateDate = DateTime.Now;
            offer.RegisterUser = record.RegisteredBy;
            offer.SanaTrackingNumber = record.SanaTrackingNumber;
            offer.Description = record.OfferDescription;
            offer.RialWage = record.IRRWage;
            offer.CurrencyWage = record.CurrencyWage;
            offer.RialAmount = record.TotalPrice;
            offer.RialPaymentDeadline = RialPaymentDeadline;
            offer.ExchangeBankAccount = acc;
            offer.RequestStatus = request?.State;
            offer.RequestType = request?.RequestType;
            offer.RequestRegisterDate = request?.RequestDate;
            offer.RegisterValidityDate = request?.ExpireDate;
            offer.RegisterCode = request?.RegisterOrderCode;
            offer.CustomerTradeType = request?.RegistererType;
            offer.RequestPaymentDeadline = request?.PaymentExpireDate;
            offer.RequestReason = request?.RequestReason;
            offer.DestinationCountry = country;
            offer.Customer = request?.Customer;
            offer.CustomerContact = request?.CustomerContact;
            offer.CustomerUser = request?.CustomerUser;
            offer.OfferDetailRead = 1;
            offer.ServerDateTimeOfferDetail = DateTime.Now;
            offer.LastNimaCheckTime = DateTime.Now;
            offer.LastNimaChangeTime = LastUpdateTime;
            offer.Enabled = true;
            offer.Swiftcode = record.SWIFTCode;
            offer.AccountNumber = record.DestinationAccount;
            offer.Iban = record.IBAN;
            offer.OtherCodes = record.OtherPaymentCode;
            offer.OtherCodesDescription = record.CodeDescription;
            offer.DestinationBankAccount = record.DestinationAccount;
            offer.BankAddress = record.BankAddress;
            offer.AccountOwnerName = record.AccountOwnerName;
            offer.AccountOwnerPhone = record.AccountOwnerPhone;
            offer.AccountOwnerAddress = record.AccountOwnerAddress;
            if (offerActive != null)
            {
                offerActive.OfferCode = record.OfferCode;
                offerActive.Currency = curr;
                offerActive.Amount = record.Amount;
                offerActive.CurrencyRate = record.CurrencyUnitPrice;
                offerActive.OfferExpireTime = expireTime;
                offerActive.RequestCode = record.RequestCode;
                offerActive.Status = state;
                offerActive.StatusText = record.State;
                offerActive.OfferDate = RegisterDate;
                offerActive.Podays = record.TransferDelayTime;
                offerActive.LastUpdateDate = DateTime.Now;
                offerActive.RegisterUser = record.RegisteredBy;
                offerActive.SanaTrackingNumber = record.SanaTrackingNumber;
                offerActive.Description = record.OfferDescription;
                offerActive.RialWage = record.IRRWage;
                offerActive.CurrencyWage = record.CurrencyWage;
                offerActive.RialAmount = record.TotalPrice;
                offerActive.RialPaymentDeadline = RialPaymentDeadline;
                offerActive.ExchangeBankAccount = acc;
                offerActive.RequestStatus = request?.State;
                offerActive.RequestType = request?.RequestType;
                offerActive.RequestRegisterDate = request?.RequestDate;
                offerActive.RegisterValidityDate = request?.ExpireDate;
                offerActive.RegisterCode = request?.RegisterOrderCode;
                offerActive.CustomerTradeType = request?.RegistererType;
                offerActive.RequestPaymentDeadline = request?.PaymentExpireDate;
                offerActive.RequestReason = request?.RequestReason;
                offerActive.DestinationCountry = country;
                offerActive.Customer = request?.Customer;
                offerActive.CustomerContact = request?.CustomerContact;
                offerActive.CustomerUser = request?.CustomerUser;
                offerActive.OfferDetailRead = 1;
                offerActive.ServerDateTimeOfferDetail = DateTime.Now;
                offerActive.LastNimaCheckTime = DateTime.Now;
                offerActive.LastNimaChangeTime = LastUpdateTime;
                offerActive.Enabled = true;
            }
            if (request == null)
            {
                request = new Request
                {
                    Country = country,
                    Amount = (decimal)record.Amount,
                    Currency = curr,
                    Isactive = true,
                    RequestCode = record.RequestCode,
                    RegisterOrderCode = 0,
                    ServerDateTimeRead = DateTime.Now
                };
            }
        }
        public NimaOfferPayment NimaOfferPaymentTransfer(PaymentRecordOffer payment, int offerCode)
        {
            DateTime date = string.IsNullOrEmpty(payment.PaymentDate) ? new DateTime() : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = payment.PaymentDate }).Date);
            var bank = _unitOfWork.NimaBanks.GetBank(payment.SourceBankName);
            var payMethod = _unitOfWork.payMethods.GetMethod(payment.PaymentType);
            var state = _unitOfWork.payStates.GetPayStatus(payment.PaymentState);

            return new NimaOfferPayment
            {
                PaymentId = payment.PaymentCode,
                PaymentDate = date,
                Amount = payment.PaymentAmount,
                SourceBank = bank,
                PaymentMethod = payMethod,
                Description = payment.PaymentDsc,
                State = state,
                OfferCode = offerCode
            };
        }
        public NimaOfferPo NimaOfferPOTransfer(PORecord po, int offerCode)
        {
            var filename = po.FileName.Split('.');
            return new NimaOfferPo
            {
                OfferCode = offerCode,
                File = new byte[] { },
                FileName = po.FileName,
                FileType = filename[filename.Count() - 1],
                Description = po.Description,
                Volume = po.Volume,
                CreateUser = "",
                CreateTime = DateTime.Now,
                Enabled = true
            };
        }
        public OfferOutRecord NewOfferTransfer(ChariswallNewDomain.Models.NimaOffer offer)
        {
            return new OfferOutRecord { OfferCode = offer.OfferCode, RequestCode = offer.RequestCode };
        }
    }
}
