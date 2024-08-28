using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string? StoreName { get; set; }

    public string? StoreAddress { get; set; }

    public string? StoreContactNumber { get; set; }

    public virtual ICollection<ShopProduct> ShopProducts { get; set; } = new List<ShopProduct>();
}
