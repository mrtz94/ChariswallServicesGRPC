﻿using System;
using System.Collections.Generic;

namespace ChariswallNewDomain.Models;

public partial class CustomerType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Value { get; set; }
}
