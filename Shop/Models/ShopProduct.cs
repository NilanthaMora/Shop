using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class ShopProduct
{
    public int Id { get; set; }

    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public decimal? ProductPrice { get; set; }

    public decimal? ProductQuantity { get; set; }

    public decimal? Discount { get; set; }

    public string? ProductModel { get; set; }

    public string? ImageUrl { get; set; }

    public int? QuantityType { get; set; }

    public int? ProductTypeId { get; set; }

    public int? Supplier { get; set; }

    public int? Store { get; set; }

    public virtual ProductType? ProductType { get; set; }

    public virtual QuantityType? QuantityTypeNavigation { get; set; }

    public virtual Store? StoreNavigation { get; set; }

    public virtual ShopSupplier? SupplierNavigation { get; set; }
}
