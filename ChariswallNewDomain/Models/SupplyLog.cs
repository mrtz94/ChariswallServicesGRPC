using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class SupplyLog
{
    public int Id { get; set; }

    public int SupplyCode { get; set; }

    public int? Customer { get; set; }

    public int? CustomerUser { get; set; }

    public int? State { get; set; }

    public string? Currency { get; set; }

    public decimal? Amount { get; set; }

    public int? Country { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? UnitRate { get; set; }

    public string? BuyerExpireTime { get; set; }

    public string? BuyerReviewTime { get; set; }

    public string? DetailLink { get; set; }

    public DateTime? SupplyRegisterDateTime { get; set; }

    public string? PaymentCondition { get; set; }

    public string? DealRules { get; set; }

    public int? ExportType { get; set; }

    public DateTime? ServerDateTime { get; set; }

    public int? RateType { get; set; }
}
