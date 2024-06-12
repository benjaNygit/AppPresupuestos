using Presupuestos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presupuestos
{
    internal static class Query
    {
        #region Area
        internal static IQueryable<Area> GetAreas()
        {
            return
                from query in Context.Instance.Areas select query;
        }

        internal static IQueryable<Area> GetAreas(Guid id)
        {
            return
                from query in Context.Instance.Areas
                where query.Id == id
                select query;
        }
        #endregion

        #region Article
        public static IQueryable<Article> GetArticles()
        {
            return
                from query in Context.Instance.Articles select query;
        }

        public static IQueryable<Article> GetArticles(Guid id)
        {
            return
                from query in Context.Instance.Articles
                where query.Id == id
                select query;
        }
        #endregion

        #region Budget
        public static IQueryable<Budget> GetBudgets()
        {
            return
                from query in Context.Instance.Budgets select query;
        }

        public static IQueryable<Budget> GetBudgets(Guid id)
        {
            return
                from query in Context.Instance.Budgets
                where query.Id == id
                select query;
        }

        public static IQueryable<Budget> GetBudgets(decimal numberAccount)
        {
            return
                from query in Context.Instance.Budgets
                where query.NumberAccount == numberAccount
                select query;
        }
        #endregion

        #region BudgetAccount
        internal static IQueryable<BudgetAccount> GetBudgetAccounts()
        {
            return
                from query in Context.Instance.BudgetAccounts select query;
        }

        internal static IQueryable<BudgetAccount> GetBudgetAccounts(Guid id)
        {
            return
                from query in Context.Instance.BudgetAccounts
                where query.Id == id
                select query;
        }

        internal static IQueryable<BudgetAccount>? GetBudgetAccounts(byte? level, decimal? numberAccount)
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

        #region Voucher
        public static IQueryable<Voucher> GetVouchers()
        {
            return from query in Context.Instance.Vouchers select query;
        }

        public static IQueryable<Voucher> GetVouchers(Guid id)
        {
            return
                from query in Context.Instance.Vouchers
                where query.Id == id
                select query;
        }

        public static IQueryable<Voucher> GetVouchers(Article article)
        {
            return
                from query in Context.Instance.Vouchers
                where query.Article == article
                select query;
        }

        public static IQueryable<Voucher> GetVouchers(Budget budget)
        {
            return
                from query in Context.Instance.Vouchers
                where query.Budget == budget
                select query;
        }

        public static IQueryable<Voucher> GetVouchers(DateOnly date)
        {
            return
                from query in Context.Instance.Vouchers
                where query.Date == date
                select query;
        }

        public static IQueryable<Voucher> GetVouchers(DateOnly date, bool before)
        {
            if (before)
            {
                return
                    from query in Context.Instance.Vouchers
                    where query.Date > date
                    select query;
            }
            else
            {
                return
                    from query in Context.Instance.Vouchers
                    where query.Date < date
                    select query;
            }
        }

        public static IQueryable<Voucher> GetVouchers(DateOnly startDate, DateOnly endDate)
        {
            return
                from query in Context.Instance.Vouchers
                where query.Date >= startDate && query.Date <= endDate
                select query;
        }
        #endregion
    }
}
