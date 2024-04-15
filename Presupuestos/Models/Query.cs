using Presupuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presupuestos
{
    internal static class Query
    {
        #region BudgetAccount
        internal static IQueryable<BudgetAccount> GetBudgetAccounts()
        {
            return
                from query in Context.Instance.BudgetAccounts select query;
        }
        #endregion
    }
}
