using System;
using System.Collections.Generic;

namespace Presupuestos;

public partial class Area
{
    public Guid Id { get; set; }

    public string Description {
        get { return this.Description; }
        set { this.Description = value.Substring(50); }
    }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
}
