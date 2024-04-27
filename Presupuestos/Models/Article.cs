using System;
using System.Collections.Generic;

namespace Presupuestos;

public partial class Article
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
