using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Protos;
using ChariswallServices.ServerChannels;
using ChariswallServices.Services.IDataSourceServices;
using HelperServer;

namespace ChariswallServices.Services.DataSourceServices
{
    public class OfferSService : IOfferSService
    {
        IUnitOfWork _unitOfWork;
        IOfferTService _dataTransferService;
        IHelperServerChannel _channel;
        public OfferSService(IUnitOfWork unitOfWork, IOfferTService dataTransferService, IHelperServerChannel channel)
        {
            _unitOfWork = unitOfWork;
            _dataTransferService = dataTransferService;
            _channel = channel;
        }
        public void processOffers(List<OfferRecord> Offers)
        {
            if (Offers.Count > 0)
            {
                ProcessActiveOffers(Offers);
                ProcessOffersRecords(Offers);
            }
        }

        private void ProcessActiveOffers(List<OfferRecord> Offers)
        {
            _unitOfWork.offersActive.RemoveAll();
            _unitOfWork.Complete();
            _unitOfWork.offersActive.AddRange(_dataTransferService.NimaOffersActiveTransfer(Offers.Where(w => w.State != "مختومه").ToList()));
            _unitOfWork.Complete();
        }

        private void ProcessOffersRecords(List<OfferRecord> Offers)
        {
            foreach (var Offer in Offers)
            {

                ChariswallNewDomain.Models.NimaOffer Offermain = _dataTransferService.OfferTransfer(Offer);
                var oldReq = _unitOfWork.offers.Find(f => f.OfferCode == Offer.OfferCode).FirstOrDefault();
                if (oldReq == null)
                    _unitOfWork.offers.Add(Offermain);
                else
                {
                    _dataTransferService.OfferFill(Offer, ref oldReq);
                    _unitOfWork.offers.Edit(oldReq);
                }
            }
            _unitOfWork.Complete();
        }

        public void processOfferDetail(OfferDetailRecord record)
        {
            var Offer = _unitOfWork.offers.Find(f => f.OfferCode == record.OfferCode).FirstOrDefault();
            var OfferActive = _unitOfWork.offersActive.Find(f => f.OfferCode == record.OfferCode).FirstOrDefault();
            var log = _dataTransferService.OfferDetailLogTransfer(record, Offer);
            var request = _unitOfWork.requests.Find(f => f.RequestCode == record.RequestCode).FirstOrDefault();

            if ((Offer != null && Offer.OfferDetailRead == 1 && !_dataTransferService.CompareOfferDetailLog(record, log)) || (Offer != null && Offer.OfferDetailRead == 0))
            {
                var newLog = _dataTransferService.OfferDetailLogTransfer(record, Offer);
                _dataTransferService.OfferDetailFill(record, ref Offer, ref OfferActive, ref request);
                _unitOfWork.offers.Edit(Offer);
                if (OfferActive != null)
                    _unitOfWork.offersActive.Edit(OfferActive);
                _unitOfWork.offersLog.Add(newLog);
                _unitOfWork.Complete();
            }
        }
        public void ProcessNimaOfferPayments(List<PaymentRecordOffer> payments, int offerCode)
        {
            var oldPays = _unitOfWork.offerPayments.Find(f => f.OfferCode == offerCode).ToList();
            List<NimaOfferPayment> offerPayments = new List<NimaOfferPayment>();
            payments.ForEach(pay =>
            {
                offerPayments.Add(_dataTransferService.NimaOfferPaymentTransfer(pay, offerCode));
            });
            if (offerPayments.Count() > 0)
            {
                _unitOfWork.offerPayments.RemoveRange(oldPays);
                _unitOfWork.Complete();
                _unitOfWork.offerPayments.AddRange(offerPayments);
                _unitOfWork.Complete();
            }
        }
        public void ProcessNimaOfferPOs(List<PORecord> records, int offerCode)
        {
            var oldPays = _unitOfWork.offerPOs.Find(f => f.OfferCode == offerCode).ToList();
            List<NimaOfferPo> offerPOs = new List<NimaOfferPo>();
            records.ForEach(po =>
            {
                offerPOs.Add(_dataTransferService.NimaOfferPOTransfer(po, offerCode));
            });
            if (offerPOs.Count() > 0)
            {
                _unitOfWork.offerPOs.RemoveRange(oldPays);
                _unitOfWork.Complete();
                _unitOfWork.offerPOs.AddRange(offerPOs);
                _unitOfWork.Complete();
            }
        }

        public NewOffers getNewOffers()
        {
            NewOffers outOffers = new NewOffers();
            var Offers = _unitOfWork.offers.GetNewOffers();
            foreach (var Offer in Offers)
                outOffers.Records.Add(_dataTransferService.NewOfferTransfer(Offer));
            return outOffers;
        }

        public NewOffers getUnfinishedOffers()
        {
            NewOffers outOffers = new NewOffers();
            var Offers = _unitOfWork.offers.GetUnfinishedOffers();
            foreach (var Offer in Offers)
                outOffers.Records.Add(_dataTransferService.NewOfferTransfer(Offer));
            return outOffers;
        }

        public string salesLastDate()
        {
            var states = new int[] { 2, 3, 4, 5, 6, 14, 17, 20 };
            var inp = new InputG2P { Date = (_unitOfWork.offers.Find(f => states.Contains(f.Status)).OrderBy(f => f.ServerDateTimeRead).FirstOrDefault()?.ServerDateTimeRead?.Date ?? DateTime.Today).AddDays(-1).ToString(), Format = 1 };
            //var inp = new InputG2P { Date = _unitOfWork.offers.Find(f => f.Status == 7).OrderByDescending(f => f.ServerDateTimeRead).FirstOrDefault().ServerDateTimeRead?.Date.AddDays(-1).ToString(), Format = 1 };
            var outp = _channel.GetClient().GregorianToPersian(inp);
            return outp.Date;
        }
    }
}
