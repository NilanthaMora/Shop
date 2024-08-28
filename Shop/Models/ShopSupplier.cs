using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class ShopSupplier
{
    public int SupplierId { get; set; }

    public string? SupplierName { get; set; }

    public string? SupplierAddress { get; set; }

    public string? SupplierContact { get; set; }

    public string? SupplierDetails { get; set; }

    public virtual ICollection<ShopProduct> ShopProducts { get; set; } = new List<ShopProduct>();
}
