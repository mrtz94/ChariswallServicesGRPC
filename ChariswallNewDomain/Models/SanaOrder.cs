using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class SanaOrder
{
    public int Id { get; set; }

    public int? Action { get; set; }

    public string TrackingNumber { get; set; } = null!;

    public int? Customer { get; set; }

    public string? Currency { get; set; }

    public double? Amount { get; set; }

    public DateTime? Date { get; set; }

    public int? State { get; set; }

    public int? PaymentStatus { get; set; }

    public string? ReferralNumber { get; set; }

    public string DetailLink { get; set; } = null!;

    public DateTime ServerDateTimeRead { get; set; }

    public string? UserCode { get; set; }

    public string? Phone { get; set; }

    public string? PrevTrackNumber { get; set; }

    public int? CustomerContact { get; set; }

    public int? DealType { get; set; }

    public double? CurrencyRate { get; set; }

    public double? RialAmount { get; set; }

    public int? Source { get; set; }

    public int? Heading { get; set; }

    public DateTime? ServerDateTimeDeatilRead { get; set; }

    public double? EuroEquivalent { get; set; }

    public int DetailRead { get; set; }

    public int? Reason { get; set; }

    public string? CurrencyAccountShaba { get; set; }
}
