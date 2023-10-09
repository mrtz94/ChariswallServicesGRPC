using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class Country
{
    public int Id { get; set; }

    public int SanaId { get; set; }

    public string Etitle { get; set; } = null!;

    public string Ftitle { get; set; } = null!;

    public bool? Enable { get; set; }

    public virtual ICollection<NimaDealActive> NimaDealActiveCountryNavigations { get; set; } = new List<NimaDealActive>();

    public virtual ICollection<NimaDealActive> NimaDealActiveDestinationCountryNavigations { get; set; } = new List<NimaDealActive>();

    public virtual ICollection<NimaDeal> NimaDealCountryNavigations { get; set; } = new List<NimaDeal>();

    public virtual ICollection<NimaDeal> NimaDealDestinationCountryNavigations { get; set; } = new List<NimaDeal>();

    public virtual ICollection<NimaDealLog> NimaDealLogs { get; set; } = new List<NimaDealLog>();
}
