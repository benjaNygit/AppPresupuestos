using System;
using System.Collections.Generic;

namespace Presupuestos;

public partial class BudgetAccount
{
    public Guid Id { get; set; }

    public Guid? BudgetAccountId { get; set; }

    public int Level { get; set; }

    public string Description { get; set; } = null!;

    public int? NumberAccount { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
}
