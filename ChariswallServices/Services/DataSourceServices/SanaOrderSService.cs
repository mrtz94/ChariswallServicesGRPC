using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Services.IDataSourceServices;

namespace ChariswallServices.Services.DataSourceServices
{
    public class SanaOrderSService : ISanaOrderSService
    {
        IUnitOfWork _unitOfWork;
        ISanaOrderTService _dataTransferService;
        public SanaOrderSService(IUnitOfWork unitOfWork, ISanaOrderTService dataTransferService)
        {
            _unitOfWork = unitOfWork;
            _dataTransferService = dataTransferService;
        }
        public void AddOrUpdateTransactionPayments(List<PaymentModel> payments, string trackingnumber)
        {
            var oldPays = _unitOfWork.sanaPays.Find(f => f.TrackingNumber == trackingnumber).ToList();
            List<SanaPayment> sanaPayments = new List<SanaPayment>();
            payments.ForEach(pay =>
            {
                sanaPayments.Add(_dataTransferService.SanaPaymentTransfer(pay, trackingnumber));
            });
            _unitOfWork.sanaPays.RemoveRange(oldPays);
            _unitOfWork.Complete();
            if (sanaPayments.Count() > 0)
            {
                _unitOfWork.sanaPays.AddRange(sanaPayments);
                _unitOfWork.Complete();
            }
        }

        public void AddOrUpdateTransaction(TransactionInput transaction)
        {
            var oldTr = _unitOfWork.sanaOrders.Find(f => f.TrackingNumber == transaction.Transaction.TrackingNumber).FirstOrDefault();
            if (oldTr == null)
            {
                oldTr = _dataTransferService.SanaOrderTransfer(transaction.Transaction);
                var log = _dataTransferService.SanaOrderSetLog(transaction.Transaction);
                _unitOfWork.sanaOrdersLog.Add(log);
                _unitOfWork.sanaOrders.Add(oldTr);
            }
            else if (_dataTransferService.SanaOrderCompare(transaction.Transaction, oldTr))
            {
                var log = _dataTransferService.SanaOrderFill(transaction.Transaction, ref oldTr);
                _unitOfWork.sanaOrdersLog.Add(log);
                _unitOfWork.sanaOrders.Edit(oldTr);
            }
            _unitOfWork.Complete();
        }

        public string GetTransaction(string trackingNumber)
        {
            var Tr = _unitOfWork.sanaOrders.Find(f => f.TrackingNumber == trackingNumber).FirstOrDefault();
            if (Tr != null) return Tr.DetailLink;
            else return "";
        }
    }
}
