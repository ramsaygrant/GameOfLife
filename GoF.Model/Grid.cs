using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Model
{
   public class Grid
    {
       //The grid consists of rows containing cells
       public IList<Row> GridObj { get; set; }
       public int RowCount { get; set; }
       public int ColumnCount { get; set; }

        public Grid(int rows, int columns)
        {
            Setup(rows, columns);
        }

        /// <summary>
        /// Setup grid using row and column count
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        private void Setup(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) throw new ArgumentOutOfRangeException("Row and Column size must be greater than zero");
            GridObj = new List<Row>();
            for (int i = 0; i < rows; i++)
            {
                Row row = new Row();
                for (int j = 0; j < columns; j++)
                {
                    Cell cell = new Cell(false);
                    row.AddCell(cell);
                }
                GridObj.Add(row);
            }
            ColumnCount = columns;
            RowCount = rows;
        }

        /// <summary>
        /// Re-initialize a grid with all dead cells
        /// </summary>
        public void ReInitialize()
        {
            Setup(RowCount, ColumnCount);
        }

        /// <summary>
        /// Indexer to get grid cell by using indexes for ease of use
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>returns cell</returns>
        public Cell this[int x, int y]
        {
            get { if (GridObj.Count <= x || ColumnCount <= y) throw new ArgumentOutOfRangeException("Argument out of bound"); 
                return GridObj[x].Cells[y]; }
            set { if (GridObj.Count <= x || ColumnCount <= y) throw new ArgumentOutOfRangeException("Argument out of bound"); 
                GridObj[x].Cells[y] = value; }
        }
        /// <summary>
        /// Indexer to get grid row by using index for ease of use
        /// </summary>
        /// <param name="x"></param>
        /// <returns>returns row</returns>
        public Row this[int x]
        {
            get { if (GridObj.Count <= x) throw new ArgumentOutOfRangeException("Argument out of bound"); return GridObj[x]; }
            set { if (GridObj.Count <= x) throw new ArgumentOutOfRangeException("Argument out of bound"); GridObj[x] = value; }
        }

        /// <summary>
        /// Toggle state of input grid cell from its current state; live to dead or vice-versa
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>        
        public void ToggleCell(int x, int y)
        {
            if (GridObj.Count <= x || ColumnCount <= y) throw new ArgumentNullException("Cell doesn't have data for required indexes");
            this[x, y].IsAlive = !this[x, y].IsAlive;
        }

        /// <summary>
        /// Inserts a new row in the grid at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="row"></param>
        public void InsertRow(int index, Row row)
        {
            if (index < 0 || index >= RowCount) throw new ArgumentOutOfRangeException("Invalid Index value: must be greater than or equal to zero and less than Row count");
            GridObj.Insert(index, row);
        }

        /// <summary>
        /// Add a new row in grid at the end of the row list
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(Row row)
        {
            GridObj.Add(row);
        }
    }
}
