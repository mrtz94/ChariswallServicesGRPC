using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.ServerChannels;
using ChariswallServices.Services.IDataServices;
using ChariswallServices.Services.IDataSourceServices;

namespace ChariswallServices.Services.DataSourceServices
{
    public class SanaOrderTService : ISanaOrderTService
    {
        IUnitOfWork _unitOfWork;
        IHelperServerChannel _channel;
        ICurrencyService _cservice;
        public SanaOrderTService(IUnitOfWork unitOfWork, IHelperServerChannel channel, ICurrencyService cservice)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
            _cservice = cservice;
        }
        public SanaOrder SanaOrderTransfer(SanaTr transaction)
        {
            var ctype = _unitOfWork.customerTypes.GetCType(transaction.CustomerType);
            var dealType = _unitOfWork.dealTypes.GetDealType(transaction.DealType);
            var heading = _unitOfWork.sanaHeadings.GetHeading(transaction.Heading);
            var paystatus = _unitOfWork.payStates.GetPayStatus(transaction.PaymentStatus);
            var source = _unitOfWork.sanaSources.GetSource(transaction.Source);
            var state = _unitOfWork.sanaStates.GetState(transaction.State);
            DateTime? registerDate = string.IsNullOrEmpty(transaction.CustomerRegisterDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = transaction.CustomerRegisterDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(transaction.Company, transaction.NationalID, ctype, registerDate, transaction.CustomerRegisterNumber, transaction.Firstname, transaction.Lastname, transaction.RepresentativeIDInquiryState);
            DateTime? contactBDate = string.IsNullOrEmpty(transaction.RepresentativeBirthdate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = transaction.RepresentativeBirthdate }).Date);
            var contact = _unitOfWork.customerContacts.GetContact(transaction.Firstname, transaction.Lastname, contactBDate, transaction.RepresentativeID,
                transaction.RepresentativeIDInquiryState, transaction.RepresentativeNationalCode, transaction.RepresentativePhone, customer, ctype);

            return new SanaOrder
            {
                TrackingNumber = transaction.TrackingNumber,
                Action = _unitOfWork.sanaActions.GetAction(transaction.Action),
                Amount = double.Parse(transaction.Amount.Replace(",", string.Empty)),
                Currency = transaction.Currency.Substring(0, 3),
                CurrencyRate = _cservice.RialAmountSet(transaction.CurrencyRate),
                Customer = customer,
                CustomerContact = contact,
                Date = DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = transaction.Date }).Date),
                DealType = dealType,
                DetailLink = transaction.DetailLink,
                DetailRead = transaction.DetailRead,
                Heading = heading,
                PaymentStatus = paystatus,
                Phone = transaction.Phone,
                PrevTrackNumber = transaction.PrevTrackNumber,
                ReferralNumber = transaction.ReferralNumber,
                RialAmount = _cservice.RialAmountSet(transaction.RialAmount),
                ServerDateTimeDeatilRead = transaction.DetailRead == 1 ? DateTime.Now : null,
                ServerDateTimeRead = DateTime.Now,
                Source = source,
                State = state,
                UserCode = transaction.UserCode,
            };
        }

        public SanaOrderLog SanaOrderFill(SanaTr transaction, ref SanaOrder oldTr)
        {
            var ctype = _unitOfWork.customerTypes.GetCType(transaction.CustomerType);
            var dealType = _unitOfWork.dealTypes.GetDealType(transaction.DealType);
            var heading = _unitOfWork.sanaHeadings.GetHeading(transaction.Heading);
            var paystatus = _unitOfWork.payStates.GetPayStatus(transaction.PaymentStatus);
            var source = _unitOfWork.sanaSources.GetSource(transaction.Source);
            var state = _unitOfWork.sanaStates.GetState(transaction.State);
            DateTime? registerDate = string.IsNullOrEmpty(transaction.CustomerRegisterDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = transaction.CustomerRegisterDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(transaction.Company, transaction.NationalID, ctype, registerDate, transaction.CustomerRegisterNumber, transaction.Firstname, transaction.Lastname, transaction.RepresentativeIDInquiryState);
            DateTime? contactBDate = string.IsNullOrEmpty(transaction.RepresentativeBirthdate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = transaction.RepresentativeBirthdate }).Date);
            var contact = _unitOfWork.customerContacts.GetContact(transaction.Firstname, transaction.Lastname, contactBDate, transaction.RepresentativeID,
                transaction.RepresentativeIDInquiryState, transaction.RepresentativeNationalCode, transaction.RepresentativePhone, customer, ctype);

            oldTr.TrackingNumber = transaction.TrackingNumber;
            oldTr.Action = _unitOfWork.sanaActions.GetAction(transaction.Action);
            oldTr.Amount = double.Parse(transaction.Amount.Replace(",", string.Empty));
            oldTr.Currency = transaction.Currency.Substring(0, 3);
            oldTr.CurrencyRate = _cservice.RialAmountSet(transaction.CurrencyRate);
            oldTr.Customer = customer;
            oldTr.CustomerContact = contact;
            oldTr.Date = string.IsNullOrEmpty(transaction.Date) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = transaction.Date }).Date);
            oldTr.DealType = dealType;
            oldTr.DetailLink = transaction.DetailLink;
            oldTr.DetailRead = transaction.DetailRead;
            oldTr.Heading = heading;
            oldTr.PaymentStatus = paystatus;
            oldTr.Phone = transaction.Phone;
            oldTr.PrevTrackNumber = transaction.PrevTrackNumber;
            oldTr.ReferralNumber = transaction.ReferralNumber;
            oldTr.RialAmount = _cservice.RialAmountSet(transaction.RialAmount);
            oldTr.ServerDateTimeDeatilRead = transaction.DetailRead == 1 ? DateTime.Now : null;
            oldTr.Source = source;
            oldTr.State = state;
            oldTr.UserCode = transaction.UserCode;

            return new SanaOrderLog
            {
                Amount = double.Parse(transaction.Amount.Replace(",", string.Empty)),
                Currency = transaction.Currency.Substring(0, 3),
                CurrencyRate = _cservice.RialAmountSet(transaction.CurrencyRate),
                DealType = dealType,
                Heading = heading,
                PaymentStatus = paystatus,
                Phone = transaction.Phone,
                PrevTrackNumber = transaction.PrevTrackNumber,
                ReferralNumber = transaction.ReferralNumber,
                RialAmount = _cservice.RialAmountSet(transaction.RialAmount),
                ServerDateTime = DateTime.Now,
                Source = source,
                State = state,
                TrackingNumber = transaction.TrackingNumber,
                UserCode = transaction.UserCode,
            };
        }

        public SanaOrderLog SanaOrderSetLog(SanaTr transaction)
        {
            var ctype = _unitOfWork.customerTypes.GetCType(transaction.CustomerType);
            var dealType = _unitOfWork.dealTypes.GetDealType(transaction.DealType);
            var heading = _unitOfWork.sanaHeadings.GetHeading(transaction.Heading);
            var paystatus = _unitOfWork.payStates.GetPayStatus(transaction.PaymentStatus);
            var source = _unitOfWork.sanaSources.GetSource(transaction.Source);
            var state = _unitOfWork.sanaStates.GetState(transaction.State);
            DateTime? registerDate = string.IsNullOrEmpty(transaction.CustomerRegisterDate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = transaction.CustomerRegisterDate }).Date);
            var customer = _unitOfWork.customers.GetCustomer(transaction.Company, transaction.NationalID, ctype, registerDate, transaction.CustomerRegisterNumber, transaction.Firstname, transaction.Lastname, transaction.RepresentativeIDInquiryState);
            DateTime? contactBDate = string.IsNullOrEmpty(transaction.RepresentativeBirthdate) ? null : DateTime.Parse(_channel.GetClient().PersianToGregorian(new HelperServer.InputP2G { Date = transaction.RepresentativeBirthdate }).Date);
            var contact = _unitOfWork.customerContacts.GetContact(transaction.Firstname, transaction.Lastname, contactBDate, transaction.RepresentativeID,
                transaction.RepresentativeIDInquiryState, transaction.RepresentativeNationalCode, transaction.RepresentativePhone, customer, ctype);

            return new SanaOrderLog
            {
                Amount = double.Parse(transaction.Amount.Replace(",", string.Empty)),
                Currency = transaction.Currency.Substring(0, 3),
                CurrencyRate = _cservice.RialAmountSet(transaction.CurrencyRate),
                DealType = dealType,
                Heading = heading,
                PaymentStatus = paystatus,
                Phone = transaction.Phone,
                PrevTrackNumber = transaction.PrevTrackNumber,
                ReferralNumber = transaction.ReferralNumber,
                RialAmount = _cservice.RialAmountSet(transaction.RialAmount),
                ServerDateTime = DateTime.Now,
                Source = source,
                State = state,
                TrackingNumber = transaction.TrackingNumber,
                UserCode = transaction.UserCode,
            };
        }

        public bool SanaOrderCompare(SanaTr transactionTemp, SanaOrder oldTr)
        {
            var transaction = SanaOrderTransfer(transactionTemp);
            if (transaction.Customer != oldTr.Customer) return true;
            if (transaction.Amount != oldTr.Amount) return true;
            if (transaction.Currency != oldTr.Currency) return true;
            if (transaction.CustomerContact != oldTr.CustomerContact) return true;
            if (transaction.PaymentStatus != oldTr.PaymentStatus) return true;
            if (transaction.State != oldTr.State) return true;
            if (transaction.TrackingNumber != oldTr.TrackingNumber) return true;
            if (transaction.CurrencyRate != oldTr.CurrencyRate) return true;
            if (transaction.DealType != oldTr.DealType) return true;
            if (transaction.Heading != oldTr.Heading) return true;
            if (transaction.Phone != oldTr.Phone) return true;
            if (transaction.ReferralNumber != oldTr.ReferralNumber) return true;
            if (transaction.Source != oldTr.Source) return true;
            if (transaction.UserCode != oldTr.UserCode) return true;
            if (transaction.DetailRead != oldTr.DetailRead) return true;

            return false;
        }

        public SanaPayment SanaPaymentTransfer(PaymentModel payment, string trackingnumber)
        {
            var shaba = payment.ExchangeAccount.Split("-")[0];
            var bank = payment.ExchangeAccount.Split("-")[1];
            var acc = _unitOfWork.ExchangeBankAccounts.GetAccount(bank, shaba);
            var pt = _unitOfWork.payTools.GetTool(payment.PaymentTool);
            var pm = _unitOfWork.payMethods.GetMethod(payment.PaymentMethod);
            var IMVC = _unitOfWork.validityChecks.GetVCheck(payment.InfoMatchValidityCheck);
            var PVC = _unitOfWork.validityChecks.GetVCheck(payment.PaymentValidityCheck);

            return new SanaPayment
            {
                ExchangeBankAccount = acc,
                PaymentMethod = pm,
                PaymentTool = pt,
                PaymentTrackingCode = payment.PaymentTrackingCode,
                RefNumber = payment.RefNumber,
                RialAmount = _cservice.RialAmountSet(payment.RialAmount),
                TrackingNumber = trackingnumber,
                PayerInfoMatchValidityCheckResult = IMVC,
                PaymentValidityCheckResult = PVC,
                ServerDateTime = DateTime.Now,
            };
        }
    }
}
