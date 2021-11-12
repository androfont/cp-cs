using System;
using System.Collections.Generic;

namespace CompetitiveProgramming.Helpers;

static class IListHelpers
{
    static void Shuffle<T>(this IList<T> list)
    {
        var rd = new Random();
        for (int i = 0; i < list.Count; i++)
        {
            int index = rd.Next(list.Count);
            T temp = list[i];
            list[i] = list[index];
            list[index] = temp;
        }
    }
}
