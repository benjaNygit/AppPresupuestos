using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presupuestos
{
    public partial class Article
    {
        public static Article? Get(Guid id) => Query.GetArticles(id).FirstOrDefault<Article>();
        public static List<Article> GetAll() => (from query in Query.GetArticles() select query).ToList<Article>();
    }
}
