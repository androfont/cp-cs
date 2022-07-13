using System.Collections.Generic;

namespace Algorithm.Helpers
{
    public static class ListHelper
    {
        public static void Swap<T>(this IList<T> source, int from, int to)
        {
            T aux = source[from];
            source[from] = source[to];
            source[to] = aux;
        }
    }
}
