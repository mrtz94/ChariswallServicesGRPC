using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class PaymentTool
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<NimaDealPayment> NimaDealPayments { get; set; } = new List<NimaDealPayment>();
}
