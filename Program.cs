using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();

            foreach (string s in args)
            {
                list.Add(s.ToLower());
            }

            Check(list);
        }

        private static void Check(List<string> list)
        {
            if (list.Count % 2 == 0)
            {
                Console.WriteLine("The number of options must be odd!");
            }
            else if (UniqueCheck(list) == false)
            {
                Console.WriteLine("Options are not unique!");
            }
            else if (list.Count < 3)
            {
                Console.WriteLine("Number of options must not be less then 3!");
            }
            else
            {
                Decision.Play(list);
            }
        }

        private static bool UniqueCheck(List<string> s) // will use LINQ
        {
            IEnumerable<string> distinct = s.Distinct();
            bool equal = s.SequenceEqual(distinct);
            return equal;
        }
    }
}
