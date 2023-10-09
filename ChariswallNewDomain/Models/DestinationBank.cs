using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class DestinationBank
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool Enable { get; set; }
}
