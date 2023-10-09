using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class NimaRateType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<NimaDealActive> NimaDealActives { get; set; } = new List<NimaDealActive>();

    public virtual ICollection<NimaDealLog> NimaDealLogs { get; set; } = new List<NimaDealLog>();

    public virtual ICollection<NimaDeal> NimaDeals { get; set; } = new List<NimaDeal>();
}
