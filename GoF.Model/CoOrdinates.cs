﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Model
{
    /// <summary>
    /// structure to hold x and y indices of grid cell
    /// </summary>
    public struct CoOrdinates
    {
        public int X;
        public int Y;
        public CoOrdinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
