using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class EndDuration
{
    public int Id { get; set; }

    public string Currency { get; set; } = null!;

    public int Type { get; set; }

    public int EndDuration1 { get; set; }

    public string? Potype { get; set; }

    public virtual CurrencySymbol CurrencyNavigation { get; set; } = null!;
}
