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

        internal static IQueryable<BudgetAccount>? GetBudgetAccounts(int? level, int? numberAccount)
        {
            if (level is not null && numberAccount is not null)
            {
                return
                    from query in Context.Instance.BudgetAccounts
                    where query.Level == level && query.NumberAccount == numberAccount
                    select query;
            }
            else if (level is not null)
            {
                return
                    from query in Context.Instance.BudgetAccounts
                    where query.Level == level
                    select query;
            }
            else if (numberAccount is not null)
            {
                return
                    from query in Context.Instance.BudgetAccounts
                    where query.NumberAccount == numberAccount
                    select query;
            }

            return default;
        }
        #endregion
    }
}
