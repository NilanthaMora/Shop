using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string PaymentId { get; set; } = null!;

    public decimal? Quantity { get; set; }

    public decimal? Price { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? PaymentType { get; set; }

    public virtual PaymentType? PaymentTypeNavigation { get; set; }
}
