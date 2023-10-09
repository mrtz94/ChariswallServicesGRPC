using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class NimaOfferPayment
{
    public int Id { get; set; }

    public string PaymentId { get; set; } = null!;

    public DateTime PaymentDate { get; set; }

    public double Amount { get; set; }

    public int SourceBank { get; set; }

    public int PaymentMethod { get; set; }

    public string? Description { get; set; }

    public int? State { get; set; }

    public int OfferCode { get; set; }
}
