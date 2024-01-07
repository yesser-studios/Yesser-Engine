using System.Collections.Generic;
using System.Linq;

namespace YesserEngine
{
    public static class ListExtensions
    {
        public static void FirstOfType<TIn, TToGet>(this List<TIn> list)
        {
            list.OfType<TToGet>().FirstOrNull();
        }


        public static object FirstOrNull<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null || !enumerable.Any())
                return null;

            return enumerable.First();
        }
    }
}
