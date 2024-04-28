using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presupuestos
{
    public partial class Budget
    {
        public static Budget? Get(Guid id) => Query.GetBudgets(id).FirstOrDefault<Budget>();
        public static Budget? Get(decimal numberAccount) => Query.GetBudgets(numberAccount).FirstOrDefault<Budget>();
        public static List<Budget> GetAll() => Query.GetBudgets().ToList<Budget>();

        public static List<Budget> GetBudgetAccount(Guid budgetAccountId)
        {
            return (
                from query in Query.GetBudgets()
                where query.BudgetAccountId == budgetAccountId
                select query).ToList<Budget>();
        }

        public static List<Budget> GetArea(Guid areaId)
        {
            return (
                from query in Query.GetBudgets()
                where query.AreaId == areaId
                select query).ToList<Budget>();
        }
    }
}
