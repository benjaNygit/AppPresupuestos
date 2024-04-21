using System;
using System.Collections.Generic;

namespace Presupuestos;

public partial class BudgetAccount
{
    public decimal NumberAccount { get; set; }

    public decimal? BudgetAccountCode { get; set; }

    public decimal Level { get; set; }

    public decimal Number { get; set; }

    public string Description { get; set; } = null!;

    public virtual BudgetAccount? BudgetAccountCodeNavigation { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual ICollection<BudgetAccount> InverseBudgetAccountCodeNavigation { get; set; } = new List<BudgetAccount>();
}
