using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Protos;
using ChariswallServices.Services.IDataSourceServices;

namespace ChariswallServices.Services.DataSourceServices
{
    public class XERateSService : IXERateSService
    {
        IUnitOfWork _unitOfWork;
        public XERateSService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ProcessRates(List<xerateInput> rates)
        {
            rates.ForEach(x => { _unitOfWork.rates.Add(new Xerate { Rate = (decimal)x.Rate, Symbol = x.Symbol, TimeStamp = DateTime.Now.Ticks, ServerDateTime = DateTime.Now }); });
            _unitOfWork.Complete();
        }
    }
}
