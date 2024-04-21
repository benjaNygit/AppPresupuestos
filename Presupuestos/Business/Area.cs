using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presupuestos
{
    public partial class Area
    {
        public static Area? Get(Guid id) => Query.GetAreas(id).FirstOrDefault<Area>();
        public static List<Area> GetAll() => (from query in Query.GetAreas() select query).ToList<Area>();
    }
}
