using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using RoundRobin;

namespace ConsoleAppGame
{
    class Decision
    {
        public static void Play(List<string> options)
        {
            string computerMove;
            List<string> winList;
            ChooseWinners(options, out computerMove, out winList);
            HMAC newHmac = new HMAC(computerMove);
            newHmac.Sign();
            UserInput(options, computerMove, winList);
            newHmac.PrintKey();
        }

        private static void UserInput(List<string> options, string computerMove, List<string> winList)
        {
            Console.WriteLine("Make your move! Input number");
            int index = 1;
            foreach (string s in options)
            {
                Console.WriteLine($"{index}.{s}\n");
                index++;
            }
            Console.WriteLine("?.help");

            string userInput = Console.ReadLine();

            if (userInput == "?")
            {
                Table table = new Table(options, winList);
                table.FillTable();
                UserInput(options, computerMove, winList);
            }
            else
            {
                int optionSize = options.Count();
                bool check = InputCheck(userInput, optionSize);
                if (check == true)
                {
                    string userMove = options[Int32.Parse(userInput)-1];
                    Console.WriteLine("///");
                    Result(computerMove, winList, userMove);
                }
                else if (check == false)
                {
                    Console.WriteLine("Wrong input. Try again:");
                    UserInput(options, computerMove, winList);
                }
            }


        }

        private static bool InputCheck(string userInput, int optionSize)
        {
            int userInputInt;
            bool isInt = Int32.TryParse(userInput, out userInputInt);
            if (userInputInt < optionSize+1 && userInputInt != 0 && isInt == true)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private static void ChooseWinners(List<string> options, out string computerMove, out List<string> winList)
        {
            computerMove = options[RandomNumberGenerator.GetInt32(0, options.Count())];
            double p = options.Count() / 2;
            double half = Math.Floor(p);

            var roundRobinList = new RoundRobinList<string>(options); //used this for circuled linked list

            winList = new List<string>();
            for (var i = 0; i < options.Count(); i++)
            {
                string o = roundRobinList.Next();
                if (computerMove == o)
                {
                    for (int j = 0; j < half; j++)
                    {
                        winList.Add(roundRobinList.Next());
                    }
                    break;
                }
            }
        }

        
        private static void Result(string computerMove, List<string> winList, string userMove)
        {
            Console.WriteLine($"Computer move: {computerMove}");
            Console.WriteLine($"Your move: {userMove}");
            if (userMove == computerMove)
            {
                Console.WriteLine("You got equal moves. It's draw");
            }
            else if (winList.Contains(userMove))
            {
                Console.WriteLine("You win!!!");
            }
            else
            {
                Console.WriteLine("You lost.");
            }
        }
    }
}
