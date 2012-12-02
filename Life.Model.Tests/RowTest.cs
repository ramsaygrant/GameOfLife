using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Life.Model.Tests
{
    [TestClass]
    public class RowTest
    {
        [TestMethod]
        public void Row_Can_Insert_Cells()
        {
           //Arrange
            Row row = new Row();
            //Act
            row.InsertCell(0, new Cell(false), 3);
            //Assert
            Assert.IsInstanceOfType(row.Cells[0], typeof(Cell));
            Assert.AreEqual(row.Cells.Count, 1);
        }
    }
}
