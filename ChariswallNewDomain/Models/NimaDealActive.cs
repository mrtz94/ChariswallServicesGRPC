using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class NimaDealActive
{
    public int Id { get; set; }

    public int? TradeCode { get; set; }

    public double Amount { get; set; }

    public int Status { get; set; }

    public string StatusText { get; set; } = null!;

    public int SupplyCode { get; set; }

    public string Supplier { get; set; } = null!;

    public int? SupplierId { get; set; }

    public string Currency { get; set; } = null!;

    public int SupplyRate { get; set; }

    public int CurrencyRateFactor { get; set; }

    public int DemandCode { get; set; }

    public string TradeDetailLink { get; set; } = null!;

    public DateTime? Podate { get; set; }

    public string? SanaTrackingNumber { get; set; }

    public DateTime? DealDate { get; set; }

    public double? RialAmount { get; set; }

    public int? SupplierBankAccount { get; set; }

    public int? RateType { get; set; }

    public double? SupplyAmount { get; set; }

    public int? Country { get; set; }

    public string? RialPaymentCondition { get; set; }

    public string? DealCondition { get; set; }

    public int? SupplierUser { get; set; }

    public int? RialPaymentMethod { get; set; }

    public double? DemandAmount { get; set; }

    public double? MinAmount { get; set; }

    public int DealDetailRead { get; set; }

    public DateTime ServerDateTimeRead { get; set; }

    public DateTime? ServerDateTimeDealDetail { get; set; }

    public string? SupplyDetailLink { get; set; }

    public string? DemandDetailLink { get; set; }

    public DateTime? SupplyRegisterDateTime { get; set; }

    public int? ExportType { get; set; }

    public DateTime? DemandDateTime { get; set; }

    public int? DestinationCountry { get; set; }

    public int? DestinationBankAccount { get; set; }

    public string? Swiftcode { get; set; }

    public string? OtherCodes { get; set; }

    public string? CodeType { get; set; }

    public string? AccountNumber { get; set; }

    public string? Iban { get; set; }

    public string? AccountOwnerName { get; set; }

    public bool? IsDeal { get; set; }

    public int? DemandRate { get; set; }

    public virtual Country? CountryNavigation { get; set; }

    public virtual Country? DestinationCountryNavigation { get; set; }

    public virtual NimaRateType? RateTypeNavigation { get; set; }

    public virtual RialPaymentMethod? RialPaymentMethodNavigation { get; set; }

    public virtual ExchangeCustomer? SupplierNavigation { get; set; }
}
