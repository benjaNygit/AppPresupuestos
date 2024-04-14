using System;
using System.Collections.Generic;

namespace Presupuestos;

public partial class Article
{
    public Guid Id { get; set; }

    public string Description {
        get { return this.Description; }
        set { this.Description = value.Substring(100); }
    }

    public decimal Value { get; set; }

    public int Amount { get; set; }

    public decimal? Total { get; set; }

    public Guid BudgetId { get; set; }

    public virtual Budget Budget { get; set; } = null!;
}
