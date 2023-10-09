namespace ChariswallServices.Services.IDataSourceServices
{
    public interface ISanaOrderSService
    {
        void AddOrUpdateTransactionPayments(List<PaymentModel> payments, string trackingnumber);
        void AddOrUpdateTransaction(TransactionInput transaction);
        string GetTransaction(string trackingNumber);
    }
}
