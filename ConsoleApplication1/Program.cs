using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoF.Model;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(200,200);
            game.MaxGenerations = 200;
            game.ToggleGridCell(0, 1);
            game.ToggleGridCell(1, 1);
            game.ToggleGridCell(1, 2);
            game.ToggleGridCell(1, 3);
            game.ToggleGridCell(2, 0);
            game.ToggleGridCell(2, 1);
            game.ToggleGridCell(2, 2);
            game.ToggleGridCell(2, 3);

            game.Play();
        }
    }
}
