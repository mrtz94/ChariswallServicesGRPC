using ChariswallNewDomain.Models;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface ISanaOrderTService
    {
        SanaOrder SanaOrderTransfer(SanaTr transaction);
        SanaOrderLog SanaOrderFill(SanaTr transaction, ref SanaOrder oldTr);
        bool SanaOrderCompare(SanaTr transaction, SanaOrder oldTr);
        SanaOrderLog SanaOrderSetLog(SanaTr transaction);
        SanaPayment SanaPaymentTransfer(PaymentModel payment, string trackingnumber);
    }
}
