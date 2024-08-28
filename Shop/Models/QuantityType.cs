using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class QuantityType
{
    public int QuantityTypeId { get; set; }

    public string? QuantityTypeName { get; set; }

    public virtual ICollection<ShopProduct> ShopProducts { get; set; } = new List<ShopProduct>();
}
