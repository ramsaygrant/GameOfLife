using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GoF.Model;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(12, 12);
            game.MaxGenerations = 400;
            game.ToggleGridCell(1,0);
            game.ToggleGridCell(1, 3);
            game.ToggleGridCell(2, 1);
            game.ToggleGridCell(2, 3);
            game.ToggleGridCell(3, 0);
            game.ToggleGridCell(3,1);
            game.ToggleGridCell(4,2);
            game.ToggleGridCell(4, 4);
            game.ToggleGridCell(4, 3);
            //game.ToggleGridCell(4, 1);
            //game.ToggleGridCell(4, 0);

            for (int i = 0; i < 200; i++)
            {
                Console.Clear();
                game.Play();
                foreach (Row r in game.InputGrid.GridObj)
                {
                    for (int j = 0; j < game.InputGrid.ColumnCount -1; j++)
                    {
                        Cell c = r.Cells[j];
                        if (c.IsAlive) { Console.Write("O"); }
                        else { Console.Write(" "); }
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(500);
            }
            Console.Read();
        }
    }
}
