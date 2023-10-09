using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class NimaOfferPo
{
    public int Id { get; set; }

    public int OfferCode { get; set; }

    public byte[]? File { get; set; }

    public string FileName { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public string? Description { get; set; }

    public string? Volume { get; set; }

    public string CreateUser { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public int? NimaRegisterStatus { get; set; }

    public DateTime? NimaRegisterTime { get; set; }

    public bool Enabled { get; set; }

    public int LastAction { get; set; }
}
