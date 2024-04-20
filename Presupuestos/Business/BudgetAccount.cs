using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Presupuestos;

namespace Presupuestos
{
    public partial class BudgetAccount
    {
        public static BudgetAccount? Get(decimal numberAccount) => Query.GetBudgetAccounts(null, numberAccount)?.FirstOrDefault<BudgetAccount>();

        public static decimal GenerateNumberAccount(BudgetAccount budgetAccount)
        {
            if (budgetAccount.BudgetAccountId is not null)
            {
                string level = budgetAccount.Level.ToString();
                if (level.Length > 1)
                    level = string.Format("0{0}", level);

                return decimal.Parse(string.Format("{0}{1}", budgetAccount.BudgetAccountId, level));
            }
            else
            {
                return budgetAccount.Level;
            }
        }

        public static List<BudgetAccount> GetAll()
        {
            return
                (from query in Query.GetBudgetAccounts()
                 select query
                 ).ToList();
        }

        public static List<BudgetAccount> GetAll(byte level, decimal numberAccount)
        {
            return (
                from query in Query.GetBudgetAccounts(level, numberAccount)
                select query
                ).ToList();
        }

        public static List<BudgetAccount> GetLevels(byte level)
        {
            return (
                from query in Query.GetBudgetAccounts(level, null)
                select query
                ).ToList();
        }
    }
}
