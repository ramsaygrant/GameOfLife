using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Model
{
    /// <summary>
    /// Cell types are unique types of cell in grid of any size
    /// Every cell type has distinct reachable adjacent cells which can be traversed
    /// </summary>
    enum CellTypeEnum
    {
        TopLeftCorner,
        TopRightCorner,
        BottomLeftCorner,
        BottomRightCorner,
        TopSide,
        BottomSide,
        LeftSide,
        RightSide,
        Center,
        OuterTopSide,
        OuterRightSide,
        OuterBottomSide,
        OuterLeftSide,
        None
    }
}
