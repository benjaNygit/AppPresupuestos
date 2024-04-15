using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presupuestos.Models;

namespace Presupuestos
{
    public partial class BudgetAccount
    {
        public static List<BudgetAccount> GetAll()
        {
            return
                (from query in Query.GetBudgetAccounts()
                 select query
                 ).ToList();
        }

        public static List<BudgetAccount> GetAll(int level, int numberAccount)
        {
            return (
                from query in Query.GetBudgetAccounts(level, numberAccount)
                select query
                ).ToList();
        }

        public static List<BudgetAccount> GetLevels(int level)
        {
            return (
                from query in Query.GetBudgetAccounts(level, null)
                select query
                ).ToList();
        }

        public static List<BudgetAccount> GetBudgetAccounts(int numberAccount)
        {
            return (
                from query in Query.GetBudgetAccounts(null, numberAccount)
                select query
                ).ToList();
        }
    }
}
