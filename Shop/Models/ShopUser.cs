using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class ShopUser
{
    public string UserId { get; set; } = null!;

    public string? UserRoll { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }
}
