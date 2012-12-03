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
            Game game = new Game(24, 24);
            game.MaxGenerations = 400;
            //game.ToggleGridCell(1, 0);
            //game.ToggleGridCell(1, 3);
            //game.ToggleGridCell(2, 1);
            //game.ToggleGridCell(2, 3);
            //game.ToggleGridCell(3, 0);
            //game.ToggleGridCell(3, 1);
            //game.ToggleGridCell(4, 2);
            //game.ToggleGridCell(4, 4);
            //game.ToggleGridCell(4, 3);

            //game.ToggleGridCell(8, 8);
            //game.ToggleGridCell(8, 6);
            //game.ToggleGridCell(8, 7);
            //game.ToggleGridCell(9, 5);
            //game.ToggleGridCell(9, 7);
            //game.ToggleGridCell(10, 7);
            //game.ToggleGridCell(10, 6);
            //game.ToggleGridCell(11, 5);
            //game.ToggleGridCell(11, 8);

            //game.ToggleGridCell(7, 6);
            //game.ToggleGridCell(7, 7);
            //game.ToggleGridCell(8, 6);
            //game.ToggleGridCell(8, 9);
            //game.ToggleGridCell(8, 10);
            //game.ToggleGridCell(9, 8);
            //game.ToggleGridCell(9, 10);
            //game.ToggleGridCell(9, 9);
            //game.ToggleGridCell(10,6);
            //game.ToggleGridCell(10, 7);

            //game.ToggleGridCell(6, 6);
            //game.ToggleGridCell(7, 6);
            //game.ToggleGridCell(8, 6);
            //game.ToggleGridCell(7, 5);
            //game.ToggleGridCell(7, 7);

            //game.ToggleGridCell(5, 7);
            //game.ToggleGridCell(6, 6);
            //game.ToggleGridCell(7, 7);
            //game.ToggleGridCell(8, 8);
            //game.ToggleGridCell(8, 6);
            //game.ToggleGridCell(6, 8);
            //game.ToggleGridCell(9, 7);
            //game.ToggleGridCell(9, 8);

            //R-Pentomino
            game.ToggleGridCell(5, 5);
            game.ToggleGridCell(5, 6);
            game.ToggleGridCell(6, 6);
            game.ToggleGridCell(4, 6);
            game.ToggleGridCell(4, 7);

            for (int i = 0; i < game.MaxGenerations; i++)
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
                Thread.Sleep(100);
            }
            Console.Read();
        }
    }
}
