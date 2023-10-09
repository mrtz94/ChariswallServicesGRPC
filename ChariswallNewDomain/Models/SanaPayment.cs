using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class SanaPayment
{
    public int Id { get; set; }

    public int ExchangeBankAccount { get; set; }

    public double RialAmount { get; set; }

    public int PaymentMethod { get; set; }

    public int PaymentTool { get; set; }

    public string? RefNumber { get; set; }

    public string? PaymentTrackingCode { get; set; }

    public string TrackingNumber { get; set; } = null!;

    public int? PaymentValidityCheckResult { get; set; }

    public int? PayerInfoMatchValidityCheckResult { get; set; }

    public DateTime ServerDateTime { get; set; }
}
