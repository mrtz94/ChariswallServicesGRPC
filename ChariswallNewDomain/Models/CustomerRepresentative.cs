using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class CustomerRepresentative
{
    public int Id { get; set; }

    public string? NationalCode { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? IdentificationNumber { get; set; }

    public string? Phone { get; set; }

    public string? IdinquiryState { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? Customer { get; set; }

    public virtual ExchangeCustomer? CustomerNavigation { get; set; }
}
