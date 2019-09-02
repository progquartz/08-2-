using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Extension_Method2
{
    public static class _15_plus
    {
        public static IEnumerable<TSource> Where<TSource>(
     this IEnumerable<TSource> source)
    }
}
