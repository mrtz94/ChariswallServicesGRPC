using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class CustomerUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int? BankBranch { get; set; }

    public int? Customer { get; set; }

    public virtual BankBranch? BankBranchNavigation { get; set; }

    public virtual ExchangeCustomer? CustomerNavigation { get; set; }

    public virtual ICollection<NimaDeal> NimaDeals { get; set; } = new List<NimaDeal>();
}
