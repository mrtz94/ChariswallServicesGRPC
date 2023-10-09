using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class NimaDealLog
{
    public int Id { get; set; }

    public int? TradeCode { get; set; }

    public double Amount { get; set; }

    public int Status { get; set; }

    public string Currency { get; set; } = null!;

    public int SupplyRate { get; set; }

    public int CurrencyRateFactor { get; set; }

    public string TradeDetailLink { get; set; } = null!;

    public DateTime? Podate { get; set; }

    public double? RialAmount { get; set; }

    public int? SupplierBankAccount { get; set; }

    public int? RateType { get; set; }

    public double? SupplyAmount { get; set; }

    public int? Country { get; set; }

    public string? RialPaymentCondition { get; set; }

    public string? DealCondition { get; set; }

    public int? RialPaymentMethod { get; set; }

    public double? DemandAmount { get; set; }

    public double? MinAmount { get; set; }

    public DateTime ServerDateTimeRead { get; set; }

    public int? ExportType { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsDeal { get; set; }

    public int DemandCode { get; set; }

    public virtual Country? CountryNavigation { get; set; }

    public virtual NimaRateType? RateTypeNavigation { get; set; }

    public virtual RialPaymentMethod? RialPaymentMethodNavigation { get; set; }

    public virtual BankBranch? SupplierBankAccountNavigation { get; set; }
}
