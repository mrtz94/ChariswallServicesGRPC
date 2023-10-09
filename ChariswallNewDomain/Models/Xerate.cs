using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class Xerate
{
    public long TimeStamp { get; set; }

    public string Symbol { get; set; } = null!;

    public decimal? Rate { get; set; }

    public DateTime? ServerDateTime { get; set; }
}
