using System;
using System.Collections.Generic;

namespace Presupuestos;

public partial class BudgetAccount
{
    public int NumberAccount { get; set; }

    public Guid? BudgetAccountId { get; set; }

    public int Level { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
}
