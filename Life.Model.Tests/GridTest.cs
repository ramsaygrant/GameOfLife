using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Life.Model;

namespace Life.Model.Tests
{
    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void Grid_Is_Seeded_With_Rows_And_Columns()
        {
            //Arrange
            Grid inputGrid = new Grid(3, 3);
            //Act
            //Assert
            Assert.AreEqual(inputGrid.GridObj.Count, 3);
            Assert.AreEqual(inputGrid.GridObj[0].Cells.Count, 3);
            Assert.AreEqual(inputGrid.GridObj[1].Cells.Count, 3);
            Assert.AreEqual(inputGrid.GridObj[2].Cells.Count, 3);
            Assert.AreEqual(inputGrid.RowCount, 3);
            Assert.AreEqual(inputGrid.ColumnCount, 3);
        }

        [TestMethod]
        public void Grid_Can_Toggle_Cells()
        {
            //Arrange
            Grid inputGrid = new Grid(3, 3);
            //Act
            inputGrid.ToggleCell(0,0);
            //Assert
            Assert.IsTrue(inputGrid.GridObj[0].Cells[0].IsAlive);

            inputGrid.ToggleCell(0, 0);
            Assert.IsFalse(inputGrid.GridObj[0].Cells[0].IsAlive);
        }

        [TestMethod]
        public void Grid_Can_Insert_Rows()
        {
            //Arrange
            Grid inputGrid = new Grid(3, 3);
            //Act
            inputGrid.InsertRow(0, new Row());
            //Assert
            Assert.AreEqual(inputGrid.GridObj.Count, 4);
        }
    }
}
