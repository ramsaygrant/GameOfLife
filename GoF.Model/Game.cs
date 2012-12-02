using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Model
{
    public class Game
    {
        /// <summary>
        /// The input grid
        /// </summary>
        public Grid InputGrid { get; set; }

        /// <summary>
        /// The output grid
        /// </summary>
        public Grid OutputGrid { get; set; }

        /// <summary>
        ///  Get number of rows in grid
        /// </summary>
        public int RowCount { get { return InputGrid.RowCount; } }

        /// <summary>
        /// Get or Set number of columns in grid
        /// </summary>
        public int ColumnCount { get { return InputGrid.ColumnCount; } }

        /// <summary>
        /// There are two Task for the Game of Life 
        /// 1. Task for changing all existing Cell Status 
        /// </summary>
        private Task EvaluateCellTask;

        /// <summary>
        /// 2. Task for expanding output gird if respective rule satifies
        /// </summary>
        private Task EvaluateGridGrowthTask;

        /// <summary>
        /// MaxGeneration is used to restrict generations of grid changes
        /// </summary>
        public int MaxGenerations { get; set; }

        /// <summary>
        /// Setup the grid
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Game(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) throw new ArgumentOutOfRangeException("Row and Column size must be greater than zero");
            this.InputGrid = new Grid(rows, columns);
            this.OutputGrid = new Grid(rows, columns);
            ReachableCell.InitializeReachableCells();
        }

        public void Play()
        {
            for (int i = 0; i < MaxGenerations; i++)
            {
                ProcessGeneration();
            }
        }

        /// <summary>
        /// Toggle cell state i.e. dead or alive
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ToggleGridCell(int x, int y)
        {
            if (InputGrid.RowCount <= x || InputGrid.ColumnCount <= y) throw new ArgumentOutOfRangeException("Argument out of bound");
            InputGrid.ToggleCell(x, y);
        }

        /// <summary>
        /// Process current generation for next generation
        /// </summary>
        private void ProcessGeneration()
        {
            SetNextGeneration();
            Tick();
            FlipGridState();
        }

        /// <summary>
        /// Handles tasks for setting next generation
        /// </summary>
        private void SetNextGeneration()
        {
            // Generate next state of the Grid if last generate state process is completed
            if ((EvaluateCellTask == null) || (EvaluateCellTask != null && EvaluateCellTask.IsCompleted))
            {
                EvaluateCellTask = ChangeCellsState();
                // ensure that Output grid existing cells are updated. 
                //Otherwise it may result in unpredictable result in output grid if row or column is added in parallel
                EvaluateCellTask.Wait();
            }
            if ((EvaluateGridGrowthTask == null) || (EvaluateGridGrowthTask != null && EvaluateGridGrowthTask.IsCompleted))
            {
                EvaluateGridGrowthTask = ChangeGridState();
            }
        }
        /// <summary>
        /// Tick ensures that previous generation taks are completed
        /// </summary>
        private void Tick()
        {
            if (EvaluateGridGrowthTask != null)
            {
                EvaluateGridGrowthTask.Wait();
            }
        }

        /// <summary>
        /// Set output grid to input grid by Deep Copy output grid into input grid
        /// </summary>
        private void FlipGridState()
        {
            GridHelper.Copy(OutputGrid, InputGrid);
            OutputGrid.ReInitialize();
        }

        /// <summary>
        /// Change state of all input cells into output cells Simultaneously using Parallel For
        /// </summary>
        /// <returns>returns EvaluateCellTask</returns>
        private Task ChangeCellsState()
        {
            return Task.Factory.StartNew(() =>
            Parallel.For(0, InputGrid.RowCount, x =>
            {
                Parallel.For(0, InputGrid.ColumnCount, y =>
                {
                    Rule.ChangeCellsState(InputGrid, OutputGrid, new CoOrdinates(x, y));
                });
            }));
        }
        /// <summary>
        /// Change state of grid if required
        /// </summary>
        /// <returns>returns EvaluateGridGrowthTask</returns>
        private Task ChangeGridState()
        {
            return Task.Factory.StartNew(delegate()
            {
                Rule.ChangeGridState(InputGrid, OutputGrid);
            }
            );
        }
    }
}
