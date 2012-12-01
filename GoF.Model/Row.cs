using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Model
{
    public class Row
    {
        // A row containing cells
        public IList<Cell> Cells { get; set; }

        /// <summary>
        /// initialize list of cells in the constructor
        /// </summary>
        public Row()
        {
            Cells = new List<Cell>();
        }

        /// <summary>
        /// Add a cell at the end of the row
        /// </summary>
        /// <param name="cell"></param>
        public void AddCell(Cell cell)
        {
            Cells.Add(cell);
        }
        /// <summary>
        /// Insert a cell into specified index position
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cell"></param>
        /// <param name="ColumnCount"></param>
        public void InsertCell(int index, Cell cell, int ColumnCount)
        {
            if (index < 0 || index >= ColumnCount) throw new ArgumentOutOfRangeException("Invalid Index value: must be greater than zero and less than Column count");
            Cells.Insert(index, cell);
        }
    }
}
