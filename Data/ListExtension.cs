using System;
using System.Collections.Generic;
using System.Linq;

namespace RVids.Data
{

    public static class ListExtension
    {
        // This is not random enough if you need extra security.
        // For that use System.Cryptography. This is good enough for my purposes.
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rand = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static IEnumerable<T> RandomizeCollection<T>(this IEnumerable<T> source)
        {
            Random rand = new Random();
            return source.OrderBy(item => rand.Next());
        }
    }

}