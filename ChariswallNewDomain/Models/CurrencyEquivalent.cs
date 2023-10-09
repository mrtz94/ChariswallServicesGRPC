using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class CurrencyEquivalent
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Eqtitle { get; set; } = null!;

    public virtual CurrencySymbol EqtitleNavigation { get; set; } = null!;
}
