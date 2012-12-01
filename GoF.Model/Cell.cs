using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Model
{
    public class Cell
    {
        // Property to hold cell state i.e. dead or alive
        public bool IsAlive { get; set; }

        public Cell(bool isAlive)
        {
            this.IsAlive = isAlive;
        }

    }
}
