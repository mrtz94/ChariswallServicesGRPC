using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class SystemConfig
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public int? Number { get; set; }

    public DateTime? Date { get; set; }

    public bool? Valid { get; set; }
}
