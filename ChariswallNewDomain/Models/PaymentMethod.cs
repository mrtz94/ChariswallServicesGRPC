using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
}
