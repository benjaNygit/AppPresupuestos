using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presupuestos
{
    public partial class Voucher
    {
        public static Voucher? Get(Guid id) => Query.GetVouchers(id).FirstOrDefault<Voucher>();
        
        public static List<Voucher> GetAll(Article article)
        {
            return (from query in Query.GetVouchers(article)
                    select query
                    ).ToList<Voucher>();
        }

        public static List<Voucher> GetAll(Budget budget)
        {
            return (from query in Query.GetVouchers(budget)
                    select query
                    ).ToList<Voucher>();
        }

        public static List<Voucher> GetAll(DateOnly date)
        {
            return (from query in Query.GetVouchers(date)
                    select query
                    ).ToList<Voucher>();
        }

        public static List<Voucher> GetAll(DateOnly date, bool before)
        {
            return (from query in Query.GetVouchers(date, before)
                    select query
                    ).ToList<Voucher>();
        }

        public static List<Voucher> GetAll(DateOnly startDate, DateOnly endDate)
        {
            return (from query in Query.GetVouchers(startDate, endDate)
                    select query
                    ).ToList<Voucher>();
        }
    }
}
