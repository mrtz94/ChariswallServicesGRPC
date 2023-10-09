using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class RequestActive
{
    public int RequestCode { get; set; }

    public int RegisterOrderCode { get; set; }

    public string Currency { get; set; } = null!;

    public decimal Amount { get; set; }

    public int? Country { get; set; }

    public DateTime? PaymentExpireDate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public int? RequestType { get; set; }

    public int? RateType { get; set; }

    public DateTime ServerDateTimeRead { get; set; }

    public int? RegistererType { get; set; }

    public string? RefUrl { get; set; }

    public bool Isactive { get; set; }

    public DateTime? ServerDateTimeDetailRead { get; set; }

    public int? State { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? RequestReason { get; set; }

    public int? TransferType { get; set; }

    public int? Customer { get; set; }

    public bool? DetailRead { get; set; }

    public int? CustomerContact { get; set; }

    public int? CustomerUser { get; set; }
}
