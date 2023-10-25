namespace ChariswallNewDomain.Models;

public partial class ExchangeBankAccount
{
    public int Id { get; set; }

    public string Bank { get; set; } = null!;

    public string ShabaNumber { get; set; } = null!;

    public bool? Enable { get; set; }
    public bool Default { get; set; }
}
