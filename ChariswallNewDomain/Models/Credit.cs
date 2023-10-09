using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class Credit
{
    /// <summary>
    /// تاریخ شمسی
    /// </summary>
    public int ShamsiInt { get; set; }

    /// <summary>
    /// اعتبار باز
    /// </summary>
    public long CreditInUse { get; set; }

    /// <summary>
    /// اعتبار
    /// </summary>
    public long CreditAmount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = null!;

    /// <summary>
    /// تاریخ و زمان سرور
    /// </summary>
    public DateTime ServerDateTime { get; set; }
}
