using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class Trusty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? DeliverDays { get; set; }
}
