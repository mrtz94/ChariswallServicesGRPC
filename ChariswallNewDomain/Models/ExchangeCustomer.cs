using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class ExchangeCustomer
{
    public int Id { get; set; }

    public int? CustomerType { get; set; }

    public string? Company { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? RegisterNumber { get; set; }

    public DateTime? RegisterDate { get; set; }

    public string? NationalCode { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public int? Industry { get; set; }

    public string? Alias { get; set; }

    public string? Ceofullname { get; set; }

    public DateTime? SystemRegisterTime { get; set; }

    public DateTime? SystemLastUpdateTime { get; set; }

    public string? SystemUsername { get; set; }

    public string? SystemPassword { get; set; }

    public string? IdinquiryState { get; set; }

    public virtual ICollection<CustomerRepresentative> CustomerRepresentatives { get; set; } = new List<CustomerRepresentative>();

    public virtual ICollection<CustomerUser> CustomerUsers { get; set; } = new List<CustomerUser>();

    public virtual ICollection<NimaDealActive> NimaDealActives { get; set; } = new List<NimaDealActive>();

    public virtual ICollection<NimaDeal> NimaDeals { get; set; } = new List<NimaDeal>();
}
