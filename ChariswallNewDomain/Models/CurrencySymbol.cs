using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class CurrencySymbol
{
    public string Symbol { get; set; } = null!;

    public string CurrencyName { get; set; } = null!;

    public virtual ICollection<CurrencyEquivalent> CurrencyEquivalents { get; set; } = new List<CurrencyEquivalent>();

    public virtual ICollection<EndDuration> EndDurations { get; set; } = new List<EndDuration>();
}
