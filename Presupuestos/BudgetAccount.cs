using System;
using System.Collections.Generic;

namespace Presupuestos;

public partial class BudgetAccount
{
    public Guid Id { get; set; }

    public Guid? BudgetAccountId { get; set; }

    public int Level {
        get { return this.Level; }
        set { this.Level = value < 0 ? value * -1 : value; }
    }

    public string Description {
        get { return this.Description; }
        set { this.Description = value.Substring(100); }
    }

    public int? NumberAccount { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
}
