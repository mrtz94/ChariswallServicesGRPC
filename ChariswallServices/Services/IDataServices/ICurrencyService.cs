namespace ChariswallServices.Services.IDataServices
{
    public interface ICurrencyService
    {
        string GetSymbol(string currency);
        string currencyRegulate(string curr);
        double RialAmountSet(string RA);
    }
}
