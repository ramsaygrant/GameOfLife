using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Model
{
    public class GameService
    {

        public GameService(int rows, int columns)
        {
            //Seed the game
            var game = new Game(3,3);
            game.MaxGenerations = 200;
            game.ToggleGridCell(0, 1);
            game.ToggleGridCell(1, 1); 
        }
  
    }
}
