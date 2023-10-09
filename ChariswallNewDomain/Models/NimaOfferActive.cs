using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class NimaOfferActive
{
    public int Id { get; set; }

    public string DetailLink { get; set; } = null!;

    public int OfferCode { get; set; }

    public string Currency { get; set; } = null!;

    public double Amount { get; set; }

    public double? CurrencyRate { get; set; }

    public int RateFactor { get; set; }

    public DateTime OfferExpireTime { get; set; }

    public int RequestCode { get; set; }

    public int Status { get; set; }

    public string StatusText { get; set; } = null!;

    public DateTime? OfferDate { get; set; }

    public int? Podays { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? RegisterUser { get; set; }

    public string? SanaTrackingNumber { get; set; }

    public string? Description { get; set; }

    public double? RialWage { get; set; }

    public double? CurrencyWage { get; set; }

    public double? RialAmount { get; set; }

    public DateTime? RialPaymentDeadline { get; set; }

    public int? ExchangeBankAccount { get; set; }

    public int? RequestStatus { get; set; }

    public int? RequestType { get; set; }

    public DateTime? RequestRegisterDate { get; set; }

    public DateTime? RegisterValidityDate { get; set; }

    public int? RegisterCode { get; set; }

    public int? CustomerTradeType { get; set; }

    public DateTime? RequestPaymentDeadline { get; set; }

    public string? RequestReason { get; set; }

    public int? DestinationCountry { get; set; }

    public int? Customer { get; set; }

    public int? CustomerContact { get; set; }

    public int? CustomerUser { get; set; }

    public int OfferDetailRead { get; set; }

    public int RequestDetailRead { get; set; }

    public DateTime? ServerDateTimeRead { get; set; }

    public DateTime? ServerDateTimeOfferDetail { get; set; }

    public DateTime? ServerDateTimeRequestDetail { get; set; }

    public double? SugestedCurrencyRate { get; set; }

    public int? SuggestedWage { get; set; }

    public bool? Added250Wage { get; set; }

    public int? Potype { get; set; }

    public DateTime? SystemCreateTime { get; set; }

    public string? CreateUser { get; set; }

    public string? Trader { get; set; }

    public string? LastUpdateUser { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public DateTime? LastTransferTryTime { get; set; }

    public int? TransferStatus { get; set; }

    public int? LocalStatus { get; set; }

    public DateTime? LastNimaCheckTime { get; set; }

    public DateTime? LastNimaChangeTime { get; set; }

    public bool? Enabled { get; set; }

    public int? LastAction { get; set; }

    public int? LastActionStatus { get; set; }

    public string? Ponumber { get; set; }

    public string? ErrorMessage { get; set; }

    public int? Industry { get; set; }

    public string? ConvertCurrency { get; set; }

    public double? OffPercentage { get; set; }

    public int? RegisterSystem { get; set; }
}
