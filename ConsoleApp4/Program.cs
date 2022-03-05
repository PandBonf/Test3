using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            var test = new[] { 1, 2, 3, 4, 5, 6 }.EnumerateFromTail(4);

            foreach (var x in test)
            {
                Console.WriteLine("(" + x.Item1 + ", " + x.Item2 + ")");
            }
        }

       
    }

    public static class Extensions
    {
        public static IEnumerable<(T, int?)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            List<(T, int?)> result = new List<(T, int?)>();

            IEnumerable<T> reverseList = enumerable.Reverse();

            int? counter = tailLength;

            foreach (var item in reverseList)
            {
                int? tail;

                if (!counter.HasValue || counter <= 0)
                {
                    tail = null;
                }
                else
                {
                    tail = counter.Value;
                    counter = counter.Value - 1;
                }

                result.Add(new(item, tail));
            }

            result.Reverse();

            return result;
        }
    }
}
