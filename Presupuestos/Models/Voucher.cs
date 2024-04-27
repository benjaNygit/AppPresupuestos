using System;
using System.Collections.Generic;

namespace Presupuestos;

public partial class Voucher
{
    public Guid Id { get; set; }

    public Guid ArticleId { get; set; }

    public Guid GudgetId { get; set; }

    public DateOnly Date { get; set; }

    public decimal Value { get; set; }

    public string Amount { get; set; } = null!;

    public decimal? Total { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Budget Gudget { get; set; } = null!;
}
