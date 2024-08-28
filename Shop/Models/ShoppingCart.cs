using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class ShoppingCart
{
    public int Id { get; set; }

    public string CartId { get; set; } = null!;

    public decimal? Quantity { get; set; }

    public decimal? Price { get; set; }
}
