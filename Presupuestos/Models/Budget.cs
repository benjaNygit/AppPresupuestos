﻿using System;
using System.Collections.Generic;

namespace Presupuestos;

public partial class Budget
{
    public Guid Id { get; set; }

    public Guid? BudgetAccountId { get; set; }

    public decimal NumberAccount { get; set; }

    public decimal ValueStart { get; set; }

    public decimal Value { get; set; }

    public DateOnly CreateDate { get; set; }

    public Guid AreaId { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual BudgetAccount? BudgetAccount { get; set; }

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
