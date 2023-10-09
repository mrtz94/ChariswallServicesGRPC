using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Protos;
using ChariswallServices.Services.IDataSourceServices;

namespace ChariswallServices.Services.DataSourceServices
{
    public class SupplySService : ISupplySService
    {
        IUnitOfWork _unitOfWork;
        ISupplyTService _dataTransferService;
        public SupplySService(IUnitOfWork unitOfWork, ISupplyTService dataTransferService)
        {
            _unitOfWork = unitOfWork;
            _dataTransferService = dataTransferService;
        }

        public void processSupplies(List<SupplyRecord> supplies)
        {
            if (supplies.Count > 0)
            {
                ProcessActiveSupplies(supplies);
                ProcessSuppliesRecords(supplies);
            }
        }

        private void ProcessActiveSupplies(List<SupplyRecord> supplies)
        {
            _unitOfWork.suppliesActive.RemoveAll();
            _unitOfWork.Complete();
            _unitOfWork.suppliesActive.AddRange(_dataTransferService.NimaSuppliesActiveTransfer(supplies));
            _unitOfWork.Complete();
        }

        private void ProcessSuppliesRecords(List<SupplyRecord> supplies)
        {
            foreach (var supply in supplies)
            {
                Supply supplymain = _dataTransferService.SupplyTransfer(supply);
                var oldsup = _unitOfWork.supplies.Find(f => f.SupplyCode == supply.SellCode).FirstOrDefault();
                if (oldsup == null)
                    _unitOfWork.supplies.Add(supplymain);
                else
                {
                    _dataTransferService.SupplyFill(supply, ref oldsup);
                    _unitOfWork.supplies.Edit(oldsup);
                }
            }
            _unitOfWork.Complete();
        }

        public void processSupplyDetail(SupplyDetailRecord record)
        {
            var supply = _unitOfWork.supplies.Find(f => f.SupplyCode == record.SupplyCode).FirstOrDefault();
            var supplyActive = _unitOfWork.suppliesActive.Find(f => f.SupplyCode == record.SupplyCode).FirstOrDefault();
            var log = _dataTransferService.SupplyDetailLogTransfer(record);
            var deals = _unitOfWork.deals.Find(f => f.SupplyCode == record.SupplyCode && string.IsNullOrWhiteSpace(f.SupplyDetailLink)).ToList();

            if ((supply != null && supply.DetailRead == 1 && !_dataTransferService.CompareSupplyDetailLog(record, log)) || (supply != null && supply.DetailRead == 0))
            {
                var newLog = _dataTransferService.SupplyDetailLogTransfer(record);
                _dataTransferService.SupplyDetailFill(record, ref supply, ref supplyActive, ref deals);
                _unitOfWork.supplies.Edit(supply);
                if (supplyActive != null)
                    _unitOfWork.suppliesActive.Edit(supplyActive);
                _unitOfWork.suppliesLog.Add(newLog);
                _unitOfWork.Complete();
            }
        }
        public NewSupplies getNewSupplies()
        {
            NewSupplies outSupplies = new NewSupplies();
            var Supplys = _unitOfWork.supplies.GetNewSupplies();
            foreach (var Supply in Supplys)
                outSupplies.Records.Add(_dataTransferService.NewSupplyTransfer(Supply));
            return outSupplies;
        }
    }
}
