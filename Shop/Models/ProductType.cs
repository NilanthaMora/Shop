using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class ProductType
{
    public int ProductTypeId { get; set; }

    public string? ProductTypeName { get; set; }

    public virtual ICollection<ShopProduct> ShopProducts { get; set; } = new List<ShopProduct>();
}
