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
        public static List<Presupuestos.BudgetAccount> GetAll()
        {
            return
                (from query in Query.GetBudgetAccounts() select query).ToList();
        }
    }
}
