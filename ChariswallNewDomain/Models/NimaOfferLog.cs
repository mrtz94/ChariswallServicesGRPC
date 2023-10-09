using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class NimaOfferLog
{
    public int Id { get; set; }

    public int OfferCode { get; set; }

    public string Currency { get; set; } = null!;

    public double Amount { get; set; }

    public double? CurrencyRate { get; set; }

    public int RateFactor { get; set; }

    public DateTime OfferExpireTime { get; set; }

    public int Status { get; set; }

    public int? Podays { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? Description { get; set; }

    public double? RialWage { get; set; }

    public double? CurrencyWage { get; set; }

    public double? RialAmount { get; set; }

    public DateTime? RialPaymentDeadline { get; set; }

    public int? ExchangeBankAccount { get; set; }

    public double? SugestedCurrencyRate { get; set; }

    public int? SuggestedWage { get; set; }

    public bool? Added250Wage { get; set; }

    public int? Potype { get; set; }

    public string? Trader { get; set; }

    public string? LastUpdateUser { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public DateTime? LastTransferTryTime { get; set; }

    public int? TransferStatus { get; set; }

    public DateTime? LastNimaChangeTime { get; set; }

    public bool? Enabled { get; set; }

    public int? LastAction { get; set; }

    public int? LastActionStatus { get; set; }

    public string? Ponumber { get; set; }

    public string? ErrorMessage { get; set; }

    public int? Industry { get; set; }

    public string? ConvertCurrency { get; set; }

    public double? OffPercentage { get; set; }

    public string? Ipaddress { get; set; }
}
