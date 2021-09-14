using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGame
{
    class Table
    {
        public List<string> options;
        public List<string> winList;
        public Table(List<string> Options, List<string> WinList)
        {
            options = Options;
            winList = WinList;
        }

        public void FillTable()
        {
            var table = new ConsoleTable("№", "Options", "Win");
            for (int i = 0; i < options.Count; i++)
            {
                if (winList.Contains(options[i]))
                {
                    table.AddRow(i + 1, options[i], "win");
                }
                else 
                {
                    table.AddRow(i + 1, options[i], "lose");
                }
            }
            table.Write();
        }
    }
}
