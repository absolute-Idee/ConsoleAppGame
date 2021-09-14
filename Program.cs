using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new List<string>();

            options = args.ToList();
            if (InputCheck(options) == true)
            {
                Decision.Play(options);
            }
            else
            {
                Input();
            }
        }

        private static void Input()
        {
            Console.WriteLine("Input not less then 3 game options. Use comma long between elements");
            var input = Console.ReadLine().ToLower();
            List<string> list = input.Split(",").ToList();
            bool check = InputCheck(list);
            if (check == false)
            {
                Input();
            }
            else
            {
                Decision.Play(list);
            }
        }
        private static bool InputCheck(List<string> list)
        {

            foreach (string s in list)
            {
                s.ToLower();
            }

            if (list.Count % 2 == 0)
            {
                Console.WriteLine("The number of options must be odd!\n\nInput again:");
                list.Clear();
                return false;
            }
            else if (UniqueCheck(list) == false)
            {
                Console.WriteLine("Options are not unique!\n\nInput again:");
                list.Clear();
                return false;
            }
            else if (list.Count < 3)
            {
                Console.WriteLine("Number of options must not be less then 3!\n\nInput again:");
                list.Clear();
                return false;
            }
            return true;
        }

        private static bool UniqueCheck(List<string> s) // will use LINQ
        {
            IEnumerable<string> distinct = s.Distinct();
            bool equal = s.SequenceEqual(distinct);
            return equal;
        }
    }
}
