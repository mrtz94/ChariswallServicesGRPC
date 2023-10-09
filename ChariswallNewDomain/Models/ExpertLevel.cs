using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class ExpertLevel
{
    public int ExpertLevelId { get; set; }

    public string ExpertlevelName { get; set; } = null!;

    public decimal MinAmount { get; set; }

    public decimal MaxAmount { get; set; }
}
