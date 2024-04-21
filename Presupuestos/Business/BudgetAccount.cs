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
        public static BudgetAccount? Get(Guid id) => Query.GetBudgetAccounts(id).FirstOrDefault<BudgetAccount>();
        public static List<BudgetAccount> GetAll() => Query.GetBudgetAccounts().ToList<BudgetAccount>();

        public static decimal GenerateNumberAccount(BudgetAccount budgetAccount)
        {
            if (budgetAccount.BudgetAccountCode is not null)
            {
                string number = budgetAccount.Number.ToString();
                if (number.Length < 2)
                    number = string.Format("0{0}", number);

                return decimal.Parse(string.Format("{0}{1}", budgetAccount.BudgetAccountCode, number));
            }
            else
            {
                return budgetAccount.Number;
            }
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
