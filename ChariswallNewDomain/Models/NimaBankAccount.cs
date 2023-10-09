using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class NimaBankAccount
{
    public int Id { get; set; }

    public int Bank { get; set; }

    public string AccountNumber { get; set; } = null!;

    public string OwnerName { get; set; } = null!;

    public int Customer { get; set; }

    public string ShabaNumber { get; set; } = null!;
}
