using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class UserAction
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Entity { get; set; } = null!;

    public string Ipaddress { get; set; } = null!;

    public int Action { get; set; }

    public DateTime ServerDateTime { get; set; }

    public int InstanceId { get; set; }
}
