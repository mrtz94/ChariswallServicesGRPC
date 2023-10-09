using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Protos;
using ChariswallServices.ServerChannels;
using ChariswallServices.Services.IDataSourceServices;
using HelperServer;

namespace ChariswallServices.Services.DataSourceServices
{
    public class DealSService : IDealSService
    {
        IUnitOfWork _unitOfWork;
        IDealTService _dataTransferService;
        IHelperServerChannel _channel;
        public DealSService(IUnitOfWork unitOfWork, IDealTService dataTransferService, IHelperServerChannel channel)
        {
            _unitOfWork = unitOfWork;
            _dataTransferService = dataTransferService;
            _channel = channel;
        }
        //nima demands
        public void processDemands(List<DemandRecord> Demands)
        {
            if (Demands.Count > 0)
            {
                ProcessActiveDemands(Demands);
                ProcessDemandsRecords(Demands);
            }
        }

        private void ProcessActiveDemands(List<DemandRecord> Demands)
        {
            _unitOfWork.dealsActive.RemoveDemands();
            _unitOfWork.Complete();
            _unitOfWork.dealsActive.AddRange(_dataTransferService.NimaDemandsActiveTransfer(Demands));
            _unitOfWork.Complete();
        }

        private void ProcessDemandsRecords(List<DemandRecord> Demands)
        {
            foreach (var Demand in Demands)
            {
                ChariswallNewDomain.Models.NimaDeal Demandmain = _dataTransferService.DemandTransfer(Demand);
                var oldReq = _unitOfWork.deals.Find(f => f.DemandCode == Demand.DemandCode).FirstOrDefault();
                if (oldReq == null)
                    _unitOfWork.deals.Add(Demandmain);
                else
                {
                    _dataTransferService.DemandFill(Demand, ref oldReq);
                    _unitOfWork.deals.Edit(oldReq);
                }
            }
            _unitOfWork.Complete();
        }

        public void processDemandDetail(DemandDetailRecord record)
        {
            var Demand = _unitOfWork.deals.Find(f => f.DemandCode == record.DemandCode).FirstOrDefault();
            var DemandActive = _unitOfWork.dealsActive.Find(f => f.DemandCode == record.DemandCode).FirstOrDefault();
            var log = _dataTransferService.DemandDetailLogTransfer(record);
            var supply = _unitOfWork.supplies.Find(f => f.SupplyCode == record.SupplyCode).FirstOrDefault();
            if ((Demand != null && Demand.DealDetailRead == 1 && !_dataTransferService.CompareDemandDetailLog(record, log)) || (Demand != null && Demand.DealDetailRead == 0))
            {
                var newLog = _dataTransferService.DemandDetailLogTransfer(record);
                _dataTransferService.DemandDetailFill(record, ref Demand, ref DemandActive, ref supply);
                if (supply == null)
                    _unitOfWork.supplies.Edit(supply);
                _unitOfWork.deals.Edit(Demand);
                if (DemandActive != null)
                    _unitOfWork.dealsActive.Edit(DemandActive);
                _unitOfWork.Complete();
                _unitOfWork.dealsLog.Add(newLog);
                _unitOfWork.Complete();
            }
        }

        //nima deals
        public void processDeals(List<DealRecord> Deals)
        {
            if (Deals.Count > 0)
            {
                ProcessActiveDeals(Deals);
                ProcessDealsRecords(Deals);
            }
        }

        private void ProcessActiveDeals(List<DealRecord> Deals)
        {
            _unitOfWork.dealsActive.RemoveDeals();
            _unitOfWork.Complete();
            _unitOfWork.dealsActive.AddRange(_dataTransferService.NimaDealsActiveTransfer(Deals.Where(w => w.State != "مختومه").ToList()));
            _unitOfWork.Complete();
        }

        private void ProcessDealsRecords(List<DealRecord> Deals)
        {
            foreach (var Deal in Deals)
            {
                //var logExist = _dataTransferService.CompareDealLog(Deal, _unitOfWork.dealsLog.GetDealLastLog(Deal.TradeCode));
                //if (!logExist) _unitOfWork.dealsLog.Add(_dataTransferService.DealLogTransfer(Deal));


                ChariswallNewDomain.Models.NimaDeal Dealmain = _dataTransferService.DealTransfer(Deal);
                var oldReq = _unitOfWork.deals.Find(f => f.TradeCode == Deal.TradeCode).FirstOrDefault();
                if (oldReq == null)
                    _unitOfWork.deals.Add(Dealmain);
                else
                {
                    _dataTransferService.DealFill(Deal, ref oldReq);
                    _unitOfWork.deals.Edit(oldReq);
                }
            }
            _unitOfWork.Complete();
        }

        public void processsDealDetail(DealDetailRecord record)
        {
            var Deal = _unitOfWork.deals.Find(f => f.TradeCode == record.TradeCode).FirstOrDefault();
            var DealActive = _unitOfWork.dealsActive.Find(f => f.TradeCode == record.TradeCode).FirstOrDefault();
            var log = _dataTransferService.DealDetailLogTransfer(record);
            var supply = _unitOfWork.supplies.Find(f => f.SupplyCode == record.SupplyCode).FirstOrDefault();

            if ((Deal != null && Deal.DealDetailRead == 1 && !_dataTransferService.CompareDealDetailLog(record, log)) || (Deal != null && Deal.DealDetailRead == 0))
            {
                var newLog = _dataTransferService.DealDetailLogTransfer(record);
                _dataTransferService.DealDetailFill(record, ref Deal, ref DealActive, ref supply);
                _unitOfWork.deals.Edit(Deal);
                if (DealActive != null)
                    _unitOfWork.dealsActive.Edit(DealActive);
                _unitOfWork.dealsLog.Add(newLog);
                _unitOfWork.Complete();
            }
        }
        public void ProcessNimaDealPayments(List<PaymentRecordDeal> payments, int tradeCode)
        {
            var oldPays = _unitOfWork.dealPayments.Find(f => f.TradeCode == tradeCode).ToList();
            List<NimaDealPayment> DealPayments = new List<NimaDealPayment>();
            payments.ForEach(pay =>
            {
                DealPayments.Add(_dataTransferService.NimaDealPaymentTransfer(pay, tradeCode));
            });
            if (DealPayments.Count() > 0)
            {
                _unitOfWork.dealPayments.RemoveRange(oldPays);
                _unitOfWork.Complete();
                _unitOfWork.dealPayments.AddRange(DealPayments);
                _unitOfWork.Complete();
            }
        }

        public NewDemands getNewDemands()
        {
            NewDemands outDemands = new NewDemands();
            var Demands = _unitOfWork.deals.GetNewDemands();
            foreach (var Demand in Demands)
                outDemands.Records.Add(_dataTransferService.NewDemandTransfer(Demand));
            return outDemands;
        }

        public NewDeals getNewDeals()
        {
            NewDeals outDeals = new NewDeals();
            var Deals = _unitOfWork.deals.GetNewDeals();
            foreach (var Deal in Deals)
                outDeals.Records.Add(_dataTransferService.NewDealTransfer(Deal));
            return outDeals;
        }
        public NewDeals getUnfinishedDeals()
        {
            NewDeals outDeals = new NewDeals();
            var Deals = _unitOfWork.deals.GetUnfinishedDeals();
            foreach (var Deal in Deals)
                outDeals.Records.Add(_dataTransferService.NewDealTransfer(Deal));
            return outDeals;
        }

        public string buysLastDate()
        {
            var states = new int[] { 25, 27, 28, 29, 31, 32 };
            var inp = new InputG2P { Date = (_unitOfWork.deals.Find(f => states.Contains(f.Status)).OrderByDescending(f => f.ServerDateTimeRead).FirstOrDefault()?.ServerDateTimeRead.Date ?? DateTime.Today).AddDays(-1).ToString(), Format = 1 };
            //var inp = new InputG2P { Date = _unitOfWork.deals.Find(f => f.Status == 6).OrderByDescending(f => f.ServerDateTimeRead).FirstOrDefault().ServerDateTimeRead.Date.AddDays(-1).ToString(), Format = 1 };
            var outp = _channel.GetClient().GregorianToPersian(inp);
            return outp.Date;
        }
    }
}
