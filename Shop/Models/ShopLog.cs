using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class ShopLog
{
    public string LogId { get; set; } = null!;

    public DateTime? LogTime { get; set; }

    public string? Description { get; set; }

    public string? Ip { get; set; }
}
