using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Services.IDataServices;
using System.Text.RegularExpressions;

namespace ChariswallServices.Services.DataServices
{
    public class CurrencyService : ICurrencyService
    {
        IUnitOfWork _unitOfWork;
        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string GetSymbol(string currency)
        {
            return _unitOfWork.symbols.GetAll().Where(f2 => currencyRegulate(f2.CurrencyName) == currencyRegulate(currency)).FirstOrDefault()?.Symbol ?? "";
        }

        public string currencyRegulate(string curr)
        {
            var tempCurr = Regex.Replace(curr.Trim(), @"\s+", " ");
            var result = _unitOfWork.currencyEQs.Find(w => w.Title == tempCurr).FirstOrDefault()?.Eqtitle ?? tempCurr;
            return result;
        }
        public double RialAmountSet(string RA)
        {
            try
            {
                return double.Parse(RA.Replace(" ریال", string.Empty).Replace(",", string.Empty));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
