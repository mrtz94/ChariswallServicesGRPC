using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class BankBranch
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<CustomerUser> CustomerUsers { get; set; } = new List<CustomerUser>();

    public virtual ICollection<NimaDealLog> NimaDealLogs { get; set; } = new List<NimaDealLog>();

    public virtual ICollection<NimaDeal> NimaDeals { get; set; } = new List<NimaDeal>();
}
